using UnityEngine;
using System.Threading;
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


        if (isGrounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            velocity.y += JumpForce; // increase y to jump
        }

        characterController.Move(velocity * Time.deltaTime); // move character (only vertical movement)

        characterController.Move(new Vector3(GameManager.Instance.Player.RunSpeed, 0, 0) * Time.deltaTime); // make character run

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

        GameManager.Instance.Player.RunSpeed += GameManager.Instance.Player.RunSpeed * Constants.RunningAccelaration;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (GameManager.Instance.Player.Health > 0)
        {
            GameManager.Instance.Player.Health--;
            transform.position = new Vector3(transform.position.x + 2, 0, 0);
            Time.timeScale = 0;
            Thread.Sleep(1000);
            Time.timeScale = 1;
        }
    }
}