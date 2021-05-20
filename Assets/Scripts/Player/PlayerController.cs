using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Inspector fields

    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    LayerMask fenceLayer;
    [SerializeField]
    float runSpeed = 1;
    [SerializeField]
    private float jumpHeight = 1;
    [SerializeField]
    private float turnSpeed = 3;

    #endregion

    #region fields

    private float gravity = -40f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private bool canTurn;

    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);
        canTurn = !Physics.CheckSphere(transform.position, 0.5f, fenceLayer, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = 0;
        }
        else
        {
            // add gravity
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(new Vector3(runSpeed, 0, 0) * Time.deltaTime);

        if (isGrounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            velocity.y += Mathf.Sqrt(-1 * jumpHeight * gravity);
        }

        if (canTurn && Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterController.Move(new Vector3(0, 0, -turnSpeed) * Time.deltaTime);
            }
            else
            {
                characterController.Move(new Vector3(0, 0, turnSpeed) * Time.deltaTime);
            }
        }

        // vertical velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
