using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score; // initiates at 0
    

    public void IncreaseScore(int amtToIncrease)
    {
        score += amtToIncrease;
        Debug.Log($"Score is now {score}.");
    }
}
