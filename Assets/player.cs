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
        // ÌáÈ ãßæäÇÊ ÇáİíÒíÇÁ æÇáÑÓæã ÇáãÊÍÑßÉ ÊáŞÇÆíÇğ
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ÇáÊÍŞŞ ãä Ãä áæÍÉ ÇáãİÇÊíÍ ãÊÕáÉ (ÃãÇä áäÙÇã ÇáÅÏÎÇá ÇáÍÏíË)
        if (Keyboard.current == null) return;

        // 1. ÇáÍÑßÉ ÇáÃİŞíÉ (íãíä æíÓÇÑ ÈÇÓÊÎÏÇã A/D Ãæ ÇáÃÓåã)
        float moveInput = 0f;

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
            transform.localScale = new Vector3(1, 1, 1); // ÇÊÌÇå Çáíãíä
        }
        else if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
            transform.localScale = new Vector3(-1, 1, 1); // ÇÊÌÇå ÇáíÓÇÑ
        }

        // ÊØÈíŞ ÇáÓÑÚÉ ÇáÃİŞíÉ ÚÈÑ ÇáİíÒíÇÁ (ãÚ ÇáÍİÇÙ Úáì ÓÑÚÉ ÇáÓŞæØ ÇáÚãæÏíÉ)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 2. İÍÕ ãÇ ÅĞÇ ßÇä ãÇÑíæ Úáì ÇáÃÑÖ
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        // 3. ÇáŞİÒ (ÚäÏ ÇáÖÛØ Úáì Space Ãæ W Ãæ ÇáÓåã ÇáÚáæí æáãÓ ÇáÃÑÖ)
        bool jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame ||
                           Keyboard.current.wKey.wasPressedThisFrame ||
                           Keyboard.current.upArrowKey.wasPressedThisFrame;

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 4. ÊÍÏíË ÇáÑÓæã ÇáãÊÍÑßÉ (Animations)
        if (anim != null)
        {
            // ÅÑÓÇá ŞíãÉ ÇáÓÑÚÉ ááÃäíãíÔä (ááÊÍæíá áÍÇáÉ ÇáÑßÖ)
            anim.SetFloat("Speed", Mathf.Abs(moveInput));

            // ÅÑÓÇá ÍÇáÉ ÇáæÌæÏ Úáì ÇáÃÑÖ (ááÊÍæíá Èíä ÇáÓŞæØ/ÇáŞİÒ æÇáæŞæİ)
            anim.SetBool("IsGrounded", isGrounded);
        }
    }
}