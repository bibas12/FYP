using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private bool isPunching;
    private bool isSecondPunch;
    private float lastPunchTime;
    public KeyCode KeyToPress;

    public float timeBetweenPunches = 0.5f; // Adjust this value to change the time between punches

    void Start()
    {
        animator = GetComponent<Animator>();
        isPunching = false;
        isSecondPunch = false;
        lastPunchTime = -Mathf.Infinity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            if (!isPunching && !isSecondPunch)
            {
                // Play the first punch animation
                isPunching = true;
                animator.SetBool("isPunching", true);
                lastPunchTime = Time.time;
                Debug.Log("punch");
            }
            else if (isPunching && !isSecondPunch && Time.time - lastPunchTime < timeBetweenPunches)
            {
                // Play the second punch animation
                isPunching = false;
                isSecondPunch = true;
                animator.SetBool("isPunching", false);
                animator.SetBool("isSecondPunch", true);
            }
        }

        if (isPunching && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            isPunching = false;
            animator.SetBool("isPunching", false);
        }

        if (isSecondPunch && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            isSecondPunch = false;
            animator.SetBool("isSecondPunch", false);
        }
    }
}
