using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 8f; // ”—⁄… Ê«÷Õ… Ê„»«‘—…
    private Rigidbody2D rb;

    void Start()
    {
        // Ã·» „ﬂÊ‰ «·›Ì“Ì«¡ «·„ÊÃÊœ ⁄·Ï „«—ÌÊ  ·ﬁ«∆Ì«
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = 0f;

        // «·Õ—ﬂ… ≈·Ï «·Ì„Ì‰
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;

            // ⁄ﬂ” «·« Ã«Â ··Ì„Ì‰
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
        // «·Õ—ﬂ… ≈·Ï «·Ì”«—
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;

            // ⁄ﬂ” «·« Ã«Â ··Ì”«—
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }

        //  Õ—Ìﬂ „«—ÌÊ ⁄‰ ÿ—Ìﬁ «·›Ì“Ì«¡ (ÌÕ«›Ÿ ⁄·Ï «·Ã«–»Ì… Ê«·”—⁄… »À»«   «„)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}