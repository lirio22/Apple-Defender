using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    //----Beetle Enemy Variables----//
    public float beetleSpeed;
    public float beetleEscapingSpeed;
    public int beetleHealth;

    //----Difficulty Variables----//
    public int wave;

    public static DifficultyManager instance;
}
