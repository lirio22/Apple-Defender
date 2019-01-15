using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    //----Beetle Enemy Variables----//
    public float cartepillarSpeed;
    public float cartepillarEscapingSpeed;
    public int cartepillarHealth;

    //----Difficulty Variables----//
    public int wave;

    public static DifficultyManager instance;
}
