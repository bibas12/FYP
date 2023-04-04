using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public KeyCode keyToPress;
    public bool canBePressed;
    private bool noteHit;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed && !noteHit)
            {
                noteHit = true;
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();

                if (transform.position.x > -4.66f)
                {
                    Debug.Log("Normal Hit");
                    GameManager.instance.NormalHit();
                    GameObject effect = Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    Destroy(effect, 0.5f); // Destroy after 0.5 seconds
                }
                else if (transform.position.x > -4.71f)
                {
                    Debug.Log("Good Hit");
                    GameManager.instance.GoodHit();
                    GameObject effect = Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Destroy(effect, 0.5f); // Destroy after 0.5 seconds
                }
                else
                {
                    Debug.Log("Perfect Hit");
                    GameManager.instance.PerfectHit();
                    GameObject effect = Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Destroy(effect, 0.5f); // Destroy after 0.5 seconds
                }
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
            GameManager.instance.NoteMissed();
            GameObject effect = Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            Destroy(effect, 0.5f); // Destroy after 0.5 seconds
        }
    }
}
