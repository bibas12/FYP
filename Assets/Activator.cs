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
                Destroy(Note);
                gm.GetComponent<GameManager1>().AddStreak();
                AddScore();
                active = false;
            }
            else if (Input.GetKeyDown(Key)&&!active)
            {
                gm.GetComponent<GameManager1>().ResetStreak();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("hit");
        active = true;
        if (col.gameObject.tag == "Note")
            Note = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        print("missed");
        active = false;
        //gm.GetComponent<GameManager1>().ResetStreak();


    }
    
    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager1>().GetScore());
    }
}