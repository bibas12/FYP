using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    public KeyCode Key;
    Boolean active = false;
    GameObject Note, gm;
    public bool createMode;
    public GameObject n;
    public AudioSource hitSound;
    public AudioSource missSound;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(Key))
                Instantiate(n, transform.position, Quaternion.identity);
        }
        else
        {
            if (Input.GetKeyDown(Key) && active)
            {
                if (Note != null)
                {
                    Destroy(Note);
                    gm.GetComponent<GameManager1>().AddStreak();
                    AddScore();
                    hitSound.PlayOneShot(hitSound.clip);
                    active = false;
                }
            }
            else if (Input.GetKeyDown(Key) && !active)
            {
                gm.GetComponent<GameManager1>().ResetStreak();
                missSound.PlayOneShot(missSound.clip);
            }
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        print("hit");
        active = true;
        if (col.gameObject.tag == "Note")
        {
            Note = col.gameObject;
            Debug.Log("Note set to " + Note.name); // added debug statement
        }
        
    }




    bool noteMissed = false;

    void OnTriggerExit2D(Collider2D col)
    {
        if (!active || noteMissed) return;

        noteMissed = true;
        missSound.PlayOneShot(missSound.clip);
        //gm.GetComponent<GameManager1>().ResetStreak();
    }


    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager1>().GetScore());
    }
}
