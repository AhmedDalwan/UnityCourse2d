using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 8f;
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
        // —»ÿ „ﬂÊ‰«  «·›Ì“Ì«¡ Ê«·—”Ê„ «·„ Õ—ﬂ…  ·ﬁ«∆Ì«
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float moveInput = 0f;

        // 1. «·Õ—ﬂ… «·√›ﬁÌ…
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
            transform.localScale = new Vector3(1, 1, 1); // « Ã«Â «·Ì„Ì‰
        }
        else if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
            transform.localScale = new Vector3(-1, 1, 1); // « Ã«Â «·Ì”«—
        }

        //  ÿ»Ìﬁ «·”—⁄… «·√›ﬁÌ…
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 2. «· Õﬁﬁ „‰ „·«„”… «·√—÷ (≈–« ﬂ«‰ ﬂ«∆‰ GroundCheck „ÊÃÊœ«)
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
        else
        {
            // ÿ—Ìﬁ… »œÌ·… „ƒﬁ … ≈–« ·„  ﬁ„ »≈‰‘«¡ GroundCheck »⁄œ: «·«⁄ „«œ ⁄·Ï ”—⁄… «·„ÕÊ— Y
            isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;
        }

        // 3. «·ﬁ›“
        bool jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame ||
                           Keyboard.current.wKey.wasPressedThisFrame;

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 4.  ÕœÌÀ «·—”Ê„ «·„ Õ—ﬂ… (Animations)
        if (anim != null)
        {
            // ≈—”«· «·”—⁄… «·„ÿ·ﬁ… ··√‰Ì„Ì‘‰ (≈–«  Õ—ﬂ°  »œ√ Õ—ﬂ… «·—ﬂ÷)
            anim.SetFloat("Speed", Mathf.Abs(moveInput));

            // ≈—”«· Õ«·… «·ÊÃÊœ ⁄·Ï «·√—÷
            anim.SetBool("IsGrounded", isGrounded);
        }
    }
}