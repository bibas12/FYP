using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    float rm;
    GameObject Needle;

    // Start is called before the first frame update
    void Start()
    {
        Needle = transform.Find("Needle").gameObject; // Find the needle game object by name
        Debug.Log("Needle object found: " + (Needle != null)); // Debug statement to check if the needle object was found
    }

    // Update is called once per frame
    void Update()
    {
        rm = PlayerPrefs.GetInt("LifeBar");

        if (Needle != null) // Check if the needle game object was found
        {
            Needle.transform.localPosition = new Vector3((rm - 25) / 25, 0, 0);
        }
        else
        {
            Debug.LogWarning("Needle object not found!"); // Debug statement if the needle game object was not found
        }
    }
}
