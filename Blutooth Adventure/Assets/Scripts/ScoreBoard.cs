using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score; // initiates at 0
    TMP_Text scoreText;

    private void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void IncreaseScore(int amtToIncrease)
    {
        score += amtToIncrease;
        scoreText.text = score.ToString();
        Debug.Log($"Score is now {score}.");
    }
}
