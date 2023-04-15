using UnityEngine;

public class GameOverOnKeyPress : MonoBehaviour
{
    public KeyCode keyToPress;
    public bool canBePressed;
    private bool noteHit;

    public GameObject hitEffect, perfectEffect;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed && !noteHit)
            {
                noteHit = true;
                gameObject.SetActive(false);

                Debug.Log("Special Note Hit");
                GameManager.instance.consecutiveMissedNotes = 4; // makes consecutive misses 2 the game
                GameObject effect = Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                Destroy(effect, 0.5f); // Destroy after 0.5 seconds
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && !noteHit)
        {
            canBePressed = false;
        }
    }
}
