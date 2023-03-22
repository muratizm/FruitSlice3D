using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = score.ToString();

    }

    public void changeScore(int change)
    {
        score += change;
        scoreText.text = score.ToString();
    }

    public int getScore(){
        return score;
    }
}
