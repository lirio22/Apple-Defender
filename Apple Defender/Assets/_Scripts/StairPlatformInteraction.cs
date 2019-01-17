using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairPlatformInteraction : MonoBehaviour {

    public PlatformEffector2D platformEffector;
    private bool canFall = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && canFall)
        {
            StartCoroutine(TurnPlatformOver());
        }
    }

    private IEnumerator TurnPlatformOver()
    {
        canFall = false;
        platformEffector.rotationalOffset = 180;
        yield return new WaitForSeconds(0.5f);
        platformEffector.rotationalOffset = 0;
        canFall = true;
       
    }
}
