using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    float rm;
    GameObject needle;
    // Start is called before the first frame update
    void Start()
    {
        needle = transform.Find("needle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rm = PlayerPrefs.GetFloat("LifeBar"); // use GetFloat instead of GetInt since LifeMeter is a float

        needle.transform.localPosition = new Vector3((rm - 25) / 25, 0, 0);
    }
}
