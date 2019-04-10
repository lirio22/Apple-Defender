using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour {

    private int maxAmmo = 10;

    //When this variable is changed, it updates the text showing the remaining ammo
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

    //This is called when the player touches the ammo box
    public void ResetCurrentAmmo()
    {
        CurrentAmmo = maxAmmo;
    }
}
