using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStack : MonoBehaviour
{
    public GameObject[] apple;

    private int appleQtd = 2;

    public void RemoveApple()
    {
        Debug.Log("Is removing");
        apple[appleQtd].SetActive(false);
        appleQtd--;
    }

    public void AddApple()
    {
        Debug.Log("Is adding");
        appleQtd++;
        apple[appleQtd].SetActive(true);        
    }
}