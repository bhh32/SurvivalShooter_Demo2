using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public delegate void ScoreChange(int newScore);
    ScoreChange OnScoreChange;

    public static int score;        // The player's score.


    Text text;                      // Reference to the Text component.


    void Awake ()
    {
        // Set up the reference.
        text = GetComponent <Text> ();

        // Reset the score.
        score = 0;

        OnScoreChange += UpdateScore;
    }


    void Update ()
    {
        if(OnScoreChange != null)
        {
            OnScoreChange(score);
        }
    }

    void UpdateScore(int newScore)
    {
        text.text = "Score: " + score;
    }
}