using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource BGM;
    public AudioSource SFX;
    public AudioSource SFXLoop;

    public AudioClip gameStartSFX;
    public AudioClip shotSFX;
    public AudioClip hitEnemySFX;
    public AudioClip stealAppleSFX;
    public AudioClip getAmmoSFX;
    public AudioClip gameOverSFX;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBMG()
    {
        BGM.Play();
    }

    public void PlayGameStartSFX()
    {
        SFX.PlayOneShot(gameStartSFX);
    }

    public void PlayShotSFX()
    {
        SFX.PlayOneShot(shotSFX);
    }

    public void PlayHitEnemySFX()
    {
        SFX.PlayOneShot(hitEnemySFX);
    }

    public void PlayStealAppleSFX()
    {
        SFX.PlayOneShot(stealAppleSFX);
    }

    public void PlayGetAmmoSFX()
    {
        SFX.PlayOneShot(getAmmoSFX);
    }

    public void PlayLowBatterySFX()
    {
        SFXLoop.Play();
    }

    public void PlayGameOverSFX()
    {
        SFX.PlayOneShot(gameOverSFX);
    }

    public void StopPlayingSFX()
    {
        SFX.Stop();
    }

    public void StopPlayingBGM()
    {
        BGM.Stop();
    }

    public void StopPlayingSFXLoop()
    {
        SFXLoop.Stop();
    }
}
