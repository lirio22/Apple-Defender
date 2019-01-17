using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScreenOff : MonoBehaviour {

    public GameObject[] blankScreen;
    private int index = 0;

    public GameObject batteryGameOverText;
    public GameObject ammoText;
    public GameObject scoreText;
    public GameObject scoreGameOverText;

    private void Start()
    {
        StartCoroutine(ActivateObjects());
    }

    private IEnumerator ActivateObjects()
    {
        blankScreen[index].SetActive(true);
        index++;
        yield return new WaitForSecondsRealtime(0.02f);
        if(index < blankScreen.Length)
        {
            StartCoroutine(ActivateObjects());
        }
        else
        {
            ammoText.SetActive(false);
            scoreText.SetActive(false);
            StartCoroutine(ShowText());
        }
    }

    private IEnumerator ShowText()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        batteryGameOverText.SetActive(true);
        scoreGameOverText.SetActive(true);
        SceneController.instance.canRestart = true;
    }
}
