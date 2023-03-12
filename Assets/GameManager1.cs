using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int multiplier = 2;
    int streak = 0;

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("LifeBar", 25);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }

    public void AddStreak()
    {
        if(PlayerPrefs.GetInt("LifeBar")+1<50)
        PlayerPrefs.SetInt("LifeBar", PlayerPrefs.GetInt("LifeBar")+1);
        streak++;
        print(streak);
        if (streak >= 24)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;
        UpdateGUI();
    }

    public void ResetStreak()
    {
        PlayerPrefs.SetInt("LifeBar", PlayerPrefs.GetInt("LifeBar") - 2);
        if (PlayerPrefs.GetInt("LifeBar") < 0)
            Lose();
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }


    void Lose()
    {
        //lose game
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multiplier);
    }
    public int GetScore()
    {
        return 100 * multiplier;
    }
}