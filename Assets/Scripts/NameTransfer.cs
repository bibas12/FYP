using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    private const string PLAYER_NAME_KEY = "PlayerName";

    public GameObject inputField;
    public GameObject textDisplay;

    private string playerName;

    private void Start()
    {
        playerName = PlayerPrefs.GetString(PLAYER_NAME_KEY, "");
        textDisplay.GetComponent<Text>().text = "Welcome" + (playerName == "" ? "" : " " + playerName);
    }

    public void StoreName()
    {
        playerName = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
        textDisplay.GetComponent<Text>().text = "Welcome" + (playerName == "" ? "" : " " + playerName);
    }
}
