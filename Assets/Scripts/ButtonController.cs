using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public Sprite againPressedImage;

    public KeyCode keyToPress;
    public float doublePressTime = 0.5f; // Time window for double press in seconds
    private float lastPressTime = -1f; // Last time the key was pressed

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if (Time.time - lastPressTime <= doublePressTime) {
                theSR.sprite = againPressedImage;
            } else {
                theSR.sprite = pressedImage;
            }
            lastPressTime = Time.time;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}