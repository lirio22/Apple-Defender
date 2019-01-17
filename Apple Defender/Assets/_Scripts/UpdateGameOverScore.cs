using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameOverScore : MonoBehaviour {

    public Text scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + ScoreManager.instance.Score.ToString();
    }
}
