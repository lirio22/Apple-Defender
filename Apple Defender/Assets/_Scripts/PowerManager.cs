using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
    public GameObject electricityEffect;

    public GameObject batteryLight;

    private float maxPowerDuration = 20f;
    private float currentPowerDuration = 20f;
    private float maxScale = 2f;
    private float currentScale = 2f;

    private bool isCharging;
    private bool canPlaySound = true;

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
            SceneController.instance.BatteryGameOver();           
        }

        if (currentPowerDuration <= maxPowerDuration / 3 && canPlaySound)
        {
            SoundManager.instance.PlayLowBatterySFX();
            canPlaySound = false;
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

        if(currentPowerDuration >= maxPowerDuration / 3)
        {
            SoundManager.instance.StopPlayingSFXLoop();
            canPlaySound = true;
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
