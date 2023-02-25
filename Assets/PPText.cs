using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PPText : MonoBehaviour
{
    public string name;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(name) + "";
    }
}
