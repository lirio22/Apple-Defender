using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStack : MonoBehaviour
{
    public GameObject[] apple;

    private int appleQtd = 2;

    public void RemoveApple()
    {
        apple[appleQtd].SetActive(false);
        appleQtd--;
    }

    public void AddApple()
    {
        appleQtd++;
        apple[appleQtd].SetActive(true);
    }
}