using UnityEngine;
using UnityEngine.InputSystem;
using Transform = UnityEngine.Transform;

public class player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 15f;
    public float jumpForce = 12f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float moveInput = 0f;

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        bool jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame ||
                           Keyboard.current.wKey.wasPressedThisFrame ||
                           Keyboard.current.upArrowKey.wasPressedThisFrame;

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveInput));

            anim.SetBool("IsGrounded", isGrounded);
        }
    }
}