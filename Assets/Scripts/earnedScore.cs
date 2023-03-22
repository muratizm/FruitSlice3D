using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class earnedScore : MonoBehaviour
{
    public Text score;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "You earned " + score.text + " points.";
    }

}
