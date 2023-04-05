using UnityEngine;

public class JumpControls : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public float maxYPosition = 0.08f; // Maximum y position
    public KeyCode KeyToPress;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; // Set initial velocity to zero
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyToPress) && transform.position.y <= maxYPosition)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (transform.position.y > maxYPosition)
        {
            rb.velocity = Vector2.zero; // Reset velocity to zero
        }
    }
}