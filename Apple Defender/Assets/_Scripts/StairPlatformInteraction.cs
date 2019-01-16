using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairPlatformInteraction : MonoBehaviour {
    public PlatformEffector2D platformEffector;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(TurnPlatformOver());
        }
    }

    private IEnumerator TurnPlatformOver()
    {
        platformEffector.rotationalOffset = 180;
        yield return new WaitForSeconds(0.5f);
        platformEffector.rotationalOffset = 0;
    }
}
