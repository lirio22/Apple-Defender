using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject titleScreen;
    public GameObject gameScreen;

    public GameObject insectGameOverObj;
    public GameObject batteryGameOverObj;

    public bool isTitleScreen = true;
    public bool canRestart;

    public static SceneController instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }

    public void Update()
    {
        if(isTitleScreen && Input.anyKeyDown)
        {
            isTitleScreen = false;
            titleScreen.SetActive(false);
            Time.timeScale = 1;
            gameScreen.SetActive(true);
            SoundManager.instance.PlayBMG();
            SoundManager.instance.PlayGameStartSFX();
        }

        if(canRestart)
        {
            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void InsectGameOver()
    {
        SoundManager.instance.PlayGameOverSFX();
        Time.timeScale = 0;
        SoundManager.instance.StopPlayingBGM();
        SoundManager.instance.StopPlayingSFXLoop();
        StartCoroutine(CallInsect());
    }

    public void BatteryGameOver()
    {
        Time.timeScale = 0;
        SoundManager.instance.StopPlayingBGM();
        SoundManager.instance.StopPlayingSFXLoop();
        batteryGameOverObj.SetActive(true);
    }

    private IEnumerator CallInsect()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        insectGameOverObj.SetActive(true);
        canRestart = true;
    }
}
