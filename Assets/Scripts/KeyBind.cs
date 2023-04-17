using UnityEngine;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] public Text button1Lbl;
    [SerializeField] public Text button2Lbl;

    private void Start()
    {
        button1Lbl.text = PlayerPrefs.GetString("CustomKey1");
        button2Lbl.text = PlayerPrefs.GetString("CustomKey2");
    }

    private void Update()
    {
        if (button1Lbl.text == "Awaiting input")
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    button1Lbl.text = keyCode.ToString();
                    PlayerPrefs.SetString("CustomKey1", keyCode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }

        if (button2Lbl.text == "Awaiting input")
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    button2Lbl.text = keyCode.ToString();
                    PlayerPrefs.SetString("CustomKey2", keyCode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
    }

    public void ChangeKey1()
    {
        button1Lbl.text = "Awaiting input";
    }

    public void ChangeKey2()
    {
        button2Lbl.text = "Awaiting input";
    }
}
