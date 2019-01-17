using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            scoreText.text = "Score: " + _score.ToString();
        }
    }
    private int _score;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }
}
