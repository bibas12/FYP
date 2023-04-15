using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private float templateHeight = 30f;

    private List<highScoreEntry> HighScoreEntryList;
    private List<Transform> HighScoreEntryTransformList;

    public void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        if (entryContainer == null)
        {
            Debug.LogError("Could not find HighScoreEntryContainer.");
            return;
        }

        if (entryTemplate == null)
        {
            Debug.LogError("Could not find HighScoreEntryTemplate.");
            return;
        }

        entryTemplate.gameObject.SetActive(false);

        HighScoreEntryList = new List<highScoreEntry>(); // Initialize HighScoreEntryList

        // Get the FinalScore from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore");

        // Add the FinalScore to the high scores list
        HighScoreEntryList.Add(new highScoreEntry { score = finalScore });

        // Sort the entry list by score
        HighScoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

        HighScoreEntryTransformList = new List<Transform>();
        for (int i = 0; i < HighScoreEntryList.Count; i++)
        {
            CreateHighscoreEntryTransform(HighScoreEntryList[i], entryContainer, HighScoreEntryTransformList, i);
        }


        HighScores highScores = new HighScores { HighScoreEntryList = HighScoreEntryList };
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("HighScoreTable"));    
        
    }

    private void CreateHighscoreEntryTransform(highScoreEntry HighScoreEntry, Transform container, List<Transform> transformList, int i)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = i + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("NameText").GetComponent<Text>().text = rankString;

        int score = HighScoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    private void AddhighscoreEntry(int score)
    {
        highScoreEntry highScoreEntry = new highScoreEntry { score = score};
    }

    
    private class HighScores
    {
        public List<highScoreEntry> HighScoreEntryList;
        
    }

    /*
     * Represent a single entry
     */
    [System.Serializable]
    private class highScoreEntry
    {
        public int score;
        public string name;
    }
}
