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

        // Load the existing high scores from PlayerPrefs
        string highScoresJson = PlayerPrefs.GetString("HighScoreTable");
        if (!string.IsNullOrEmpty(highScoresJson))
        {
            HighScores highScores = JsonUtility.FromJson<HighScores>(highScoresJson);
            HighScoreEntryList = highScores.HighScoreEntryList;
        }

        // Get the FinalScore from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore");

        // Add the FinalScore to the high scores list
        AddhighscoreEntry(finalScore);

        // Sort the entry list by score
        HighScoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

        // Get the total number of entries to show (maximum 6)
        int numEntriesToShow = Mathf.Min(HighScoreEntryList.Count, 6);

        HighScoreEntryTransformList = new List<Transform>();
        for (int i = 0; i < numEntriesToShow; i++)
        {
            CreateHighscoreEntryTransform(HighScoreEntryList[i], entryContainer, HighScoreEntryTransformList, i);
        }

        // Save the updated high score list to PlayerPrefs
        HighScores updatedHighScores = new HighScores { HighScoreEntryList = HighScoreEntryList };
        string updatedHighScoresJson = JsonUtility.ToJson(updatedHighScores);
        PlayerPrefs.SetString("HighScoreTable", updatedHighScoresJson);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetString("HighScoreTable"));
    }


    private void LoadHighScoreTable()
    {
        string json = PlayerPrefs.GetString("HighScoreTable");
        if (!string.IsNullOrEmpty(json))
        {
            HighScores highScores = JsonUtility.FromJson<HighScores>(json);
            HighScoreEntryList = highScores.HighScoreEntryList;
        }
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
        highScoreEntry highScoreEntry = new highScoreEntry { score = score };
        HighScoreEntryList.Add(highScoreEntry);
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
    }
}
