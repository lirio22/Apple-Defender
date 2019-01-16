using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
    public GameObject electricityEffect;

    public GameObject batteryLight;

    private float maxPowerDuration = 20f;
    private float currentPowerDuration = 20f;
    private float maxScale = 1.6f;
    private float currentScale = 1.6f;

    private bool isCharging;

    private void Update()
    {
        if (isCharging)
        {
            IncreaseTime();
        }
        else
        {
            DecreaseTime();
        }
    }

    private void DecreaseTime()
    {
        currentPowerDuration -= Time.deltaTime;
        if (currentPowerDuration <= 0)
        {
            //Chama o Game Over
        }
        UpdateBatteryLight();
    }

    private void IncreaseTime()
    {
        currentPowerDuration += Time.deltaTime * 6;
        if (currentPowerDuration >= maxPowerDuration)
        {
            currentPowerDuration = maxPowerDuration;
        }
        UpdateBatteryLight();
    }

    private void UpdateBatteryLight()
    {
        currentScale = (maxScale * currentPowerDuration) / maxPowerDuration;
        batteryLight.transform.localScale = new Vector3(currentScale, currentScale, batteryLight.transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            electricityEffect.SetActive(true);
            isCharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            electricityEffect.SetActive(false);
            isCharging = false;
        }
    }
}
