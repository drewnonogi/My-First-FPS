using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public static PlayerController PlayerControllerInstance { get; private set;}
    [SerializeField] private Animator animator;
    private float mouseSensitivity = 100f;
    [SerializeField] private Transform cameraTransform;
    private float xRotation = 0f;
    private float speed = 8f;
    [SerializeField] private float yMovmentSpeed = -20f;
    private float jumpHeight = 3f;

    [SerializeField] private Transform bottomPoint;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    [SerializeField] private CharacterController characterController;

    private void Awake()
    {
        if (PlayerControllerInstance == null)
        {
            PlayerControllerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(bottomPoint.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * yMovmentSpeed);
        }


        velocity.y += yMovmentSpeed * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        animator.SetBool("IsWalking", IsWalking(move));
    }
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    private bool IsWalking(Vector3 move)
    {
        if (move == Vector3.zero)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void LaunchPlayer(Vector3 launchVelocity)
    {
        velocity = launchVelocity;
    }

}
