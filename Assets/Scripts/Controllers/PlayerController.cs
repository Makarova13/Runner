﻿using UnityEngine;
using Assets.Scripts.Common;

public class PlayerController : MonoBehaviour
{
    #region Inspector fields

    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    private float jumpHeight = 1;
    [SerializeField]
    private float groundDistance = 0.1f;

    #endregion

    #region fields

    private float gravity = -40f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    #endregion

    #region readonly properties

    private float JumpForce => Mathf.Sqrt(-1 * jumpHeight * gravity); // property used to calculate jump height

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer, QueryTriggerInteraction.Ignore); // I use CheckSphere instead of characterController.isGrounded bc I found it buggy

        if (isGrounded && velocity.y <= 0) // if is already grounded
        {
            velocity.y = 0; // to stop velocity increasing following the gravity
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // add gravity
        }

        characterController.Move(new Vector3(GameManager.Instance.Player.RunSpeed, 0, 0) * Time.deltaTime); // make character run

        if (isGrounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            velocity.y += JumpForce; // increase y to jump
        }

        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0 && characterController.transform.position.z >= 0)
            {
                if (characterController.transform.position.z >= 0)
                {
                    characterController.Move(new Vector3(0, 0, -1));
                }
            }
            else if (characterController.transform.position.z <= 0)
            {
                characterController.Move(new Vector3(0, 0, 1));
            }
        }
        
        characterController.Move(velocity * Time.deltaTime); // move character (only vertical movment)
        GameManager.Instance.Player.RunSpeed += GameManager.Instance.Player.RunSpeed * Constants.RunningAccelaration;
    }
}