using UnityEngine;
using UnityEngine.UI;

public class PressAnyKeyToContinue : MonoBehaviour
{
    public GameObject panel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            panel.SetActive(false);
        }
    }
}
