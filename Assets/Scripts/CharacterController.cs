using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private bool isPunching;
    private Rigidbody2D rb;
    public KeyCode KeyToPress;
    public float fallSpeed = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
        isPunching = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyToPress) && !isPunching)
        {
            isPunching = true;
            animator.SetBool("isPunching1", true);
            rb.velocity = new Vector2(0, -fallSpeed);
        }
        else if (isPunching && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            isPunching = false;
            animator.SetBool("isPunching1", false);
        }
    }
}
