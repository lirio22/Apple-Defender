using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour {

    private int maxAmmo = 10;

    public int CurrentAmmo
    {
        get
        {
            return _currentAmmo;
        }
        set
        {
            _currentAmmo = value;
            UpdateText();
        }
    }
    private int _currentAmmo = 10;

    public Text ammoText;

    public void UpdateText()
    {
        ammoText.text = "AMMO x" + CurrentAmmo.ToString();
    }

    public void ResetCurrentAmmo()
    {
        CurrentAmmo = maxAmmo;
    }
}
