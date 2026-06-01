using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class MovimientoJugardor : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float sprintSpeed = 9f;
    public float gravity = -9.81f;

    [Header("Salto")]
    public float jumpHeight = 2f;

    [Header("Cámara")]
    public Transform cameraTransform;

    [Header("Sprint")]
    public float maxSprint = 100f;
    public float currentSprint;
    public float sprintDrain = 20f;
    public float sprintRegen = 15f;
    public Slider sprintBar;

    private CharacterController controller;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        currentSprint = maxSprint;

        if (sprintBar != null)
        {
            sprintBar.maxValue = maxSprint;
            sprintBar.value = currentSprint;
        }
    }

    void Update()
    {
        MovePlayer();
        UpdateSprintBar();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * vertical + right * horizontal).normalized;

        bool isMoving = moveDir != Vector3.zero;
        bool wantsToSprint = Input.GetKey(KeyCode.LeftShift);
        bool canSprint = currentSprint > 0;

        float currentSpeed = speed;

        if (wantsToSprint && canSprint && isMoving)
        {
            currentSpeed = sprintSpeed;
            currentSprint -= sprintDrain * Time.deltaTime;
        }
        else
        {
            currentSprint += sprintRegen * Time.deltaTime;
        }

        currentSprint = Mathf.Clamp(currentSprint, 0, maxSprint);

        if (isMoving)
        {
            controller.Move(moveDir * currentSpeed * Time.deltaTime);
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateSprintBar()
    {
        if (sprintBar != null)
        {
            sprintBar.value = currentSprint;
        }
    }
}
