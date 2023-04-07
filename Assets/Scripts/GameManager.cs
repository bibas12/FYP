    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        public AudioSource theMusic;

        public bool startPlaying;

        public BeatScroller theBS;

        public static GameManager instance;

        public int currentScore;
        public int scorePerNote = 100;
        public int scorePerGoodNote = 125;
        public int scorePerPerfectNote = 150;

        public Text scoreText;
        public Text multiText;
        public Text consecutiveMissedNotesText;
        public Text continousHitText;


        public int currentMultiplier;
        public int multiplierTracker;
        public int[] multiplierThresholds;

        public float totalNotes;
        public float normalHits;
        public float goodHits;
        public float perfectHits;
        public float missedHits;

        public int consecutiveMissedNotes;
        public int continousHit;

        public GameObject comboBox;
        public GameObject resultsScreen;
        public Text percentHitText, normalsText, goodText, perfectText, missesText, rankText, finalScoreText;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;

            scoreText.text = "Score: 0";
            currentMultiplier = 1;

            totalNotes = FindObjectsOfType<NoteObject>().Length;
        }

        // Update is called once per frame
        void Update()
        {
            if (!startPlaying)
            {
                if (Input.anyKeyDown)
                {
                    startPlaying = true;
                    theBS.hasStarted = true;

                    theMusic.Play();
                }
            }
            else
            {
                if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
                {
                    resultsScreen.SetActive(true);
                    continousHitText.gameObject.SetActive(false);

                    normalsText.text = "" + normalHits;
                    goodText.text = goodHits.ToString();
                    perfectText.text = perfectHits.ToString();
                    missesText.text = "" + missedHits;

                    float totalHit = normalHits + goodHits + perfectHits;
                    float percentHit = (totalHit / totalNotes) * 100f;

                    percentHitText.text = percentHit.ToString("F1") + "%";

                    string rankVal = "F";

                    if (percentHit > 40)
                    {
                        rankVal = "D";
                        if (percentHit > 55)
                        {
                            rankVal = "C";
                            if (percentHit > 70)
                            {
                                rankVal = "B";
                                if(percentHit > 85)
                                {
                                    rankVal = "A";
                                    if (percentHit > 95)
                                    {
                                        rankVal = "S";
                                    }
                                }

                            }
                        }
                    }

                    rankText.text = rankVal;

                    finalScoreText.text = currentScore.ToString();
                }
            }
        }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        // Reset the consecutive missed notes counter
        consecutiveMissedNotes = 0;

        continousHit++;

        continousHitText.gameObject.SetActive(true);


        if (multiplierThresholds.Length == 0 || currentMultiplier - 1 >= multiplierThresholds.Length)
        {
            // No thresholds defined or max multiplier reached, don't increase multiplier
            currentScore += scorePerNote * currentMultiplier;
        }
        else
        {
            multiplierTracker++;

            if (multiplierTracker >= multiplierThresholds[currentMultiplier - 1])
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        consecutiveMissedNotesText.text = "Misses: " + consecutiveMissedNotes;
        continousHitText.text = "Combo: x" + continousHit;
    }


    public void NormalHit()
        {
            currentScore += scorePerNote * currentMultiplier;
            NoteHit();
            Debug.Log("Normal Hit");

            normalHits++;
        }

        public void GoodHit()
        {
            currentScore += scorePerGoodNote * currentMultiplier;
            NoteHit();
            goodHits++;
        }

        public void PerfectHit()
        {
            currentScore += scorePerPerfectNote * currentMultiplier;
            NoteHit();
            perfectHits++;
        }

    

        public void NoteMissed()
        {
            Debug.Log("Note Missed");

            continousHit = 0;
            continousHitText.gameObject.SetActive(false);

            consecutiveMissedNotes++;
            consecutiveMissedNotesText.text = "Misses: " + consecutiveMissedNotes;

        if (consecutiveMissedNotes >= 4)
            {
                // Call a game over function to end the game
                GameOver();
                Debug.Log("GameLost");
            }
            else
            {
                currentMultiplier = 1;
                multiplierTracker = 0;

                multiText.text = "Multiplier: x" + currentMultiplier;

                missedHits++;
            }
        }

        void GameOver()
        {
            // Pause the music
            theMusic.Pause();

            // Display a game over screen or perform any other actions you want
            resultsScreen.SetActive(true);
            continousHitText.gameObject.SetActive(false);

            normalsText.text = "" + normalHits;
            goodText.text = goodHits.ToString();
            perfectText.text = perfectHits.ToString();
            missesText.text = "" + missedHits;

            float totalHit = normalHits + goodHits + perfectHits;
            float percentHit = (totalHit / totalNotes) * 100f;

            percentHitText.text = percentHit.ToString("F1") + "%";

            string rankVal = "F";

            if (percentHit > 40)
            {
                rankVal = "D";
                if (percentHit > 55)
                {
                    rankVal = "C";
                    if (percentHit > 70)
                    {
                        rankVal = "B";
                        if (percentHit > 85)
                        {
                            rankVal = "A";
                            if (percentHit > 95)
                            {
                                rankVal = "S";
                            }
                        }
                    }
                }
            }

            rankText.text = rankVal;

            finalScoreText.text = currentScore.ToString();
        }

    }
