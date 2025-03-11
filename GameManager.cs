using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public float currentScore = 0f;
    public bool isPlaying = true;
    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        currentScore = 0f;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
