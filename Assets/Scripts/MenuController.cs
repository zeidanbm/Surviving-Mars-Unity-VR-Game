using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button backBtn;
    public Button startBtn;
    public Button settingsBtn;
    public Button quitBtn;
    public GameObject musicVolumeWrapper;
    public Slider musicVolumeSlider;
    public GameObject playerSpeedWrapper;
    public Slider playerSpeedSlider;
    public AudioSource backgroundMusicAudio;

    private int playerSpeed;

    public void Start()
    {
        backBtn.gameObject.SetActive(false);

        if(PlayerPrefs.GetInt("playerSpeed") > 0)
        {
            playerSpeed = PlayerPrefs.GetInt("playerSpeed");
            playerSpeedSlider.value = PlayerPrefs.GetInt("playerSpeed");
        } else
        {
            playerSpeed = Constants.PLAYER_SPEED;
            playerSpeedSlider.value = Constants.PLAYER_SPEED;
        }
    }

    private void Update()
    {
        backgroundMusicAudio.volume = musicVolumeSlider.value;
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void loadMainMenu()
    {
        StartCoroutine(FadeInBtn(
            startBtn.GetComponent<Button>()
        ));
        StartCoroutine(FadeInBtn(
            settingsBtn.GetComponent<Button>()
        ));
        StartCoroutine(FadeInBtn(
            quitBtn.GetComponent<Button>()
        ));

        StartCoroutine(FadeOutBtn(
            backBtn.GetComponent<Button>()
        ));

        toggleSettingsContent(false);
    }

    public void loadSettings()
    {
        StartCoroutine(FadeOutBtn(
            startBtn.GetComponent<Button>()
        ));
        StartCoroutine(FadeOutBtn(
            settingsBtn.GetComponent<Button>()
        ));
        StartCoroutine(FadeOutBtn(
            quitBtn.GetComponent<Button>()
        ));

        StartCoroutine(FadeInBtn(
            backBtn.GetComponent<Button>()
        ));

        toggleSettingsContent(true);
    }

    private void toggleSettingsContent(bool flag)
    {
        playerSpeedWrapper.SetActive(flag);
        musicVolumeWrapper.SetActive(flag);
    }

    public void incrementSpeed()
    {
        playerSpeedSlider.value += 1;

        playerSpeed = (playerSpeed < 10) ? playerSpeed + 1 : playerSpeed;
        PlayerPrefs.SetInt("playerSpeed", playerSpeed);
    }

    public void decrementSpeed()
    {
        playerSpeedSlider.value -= 1;

        playerSpeed = (playerSpeed > 1) ? playerSpeed - 1 : playerSpeed;
        PlayerPrefs.SetInt("playerSpeed", playerSpeed);
    }

    public void incrementSound()
    {
        musicVolumeSlider.value += 0.1f;
    }

    public void decrementSound()
    {
        musicVolumeSlider.value -= 0.1f;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public IEnumerator FadeInBtn(Button faddingBtn)
    {
        TMPro.TextMeshProUGUI textMeshPro = faddingBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        Color textColor = textMeshPro.color;
        Color btnColor = faddingBtn.image.color;

        for (float f = 0.05f; f <= 0.8; f += 0.05f)
        {
            textColor.a = f;
            textMeshPro.color = textColor;

            btnColor.a = f;
            faddingBtn.image.color = btnColor;
            yield return new WaitForSeconds(0.05f);
        }

        faddingBtn.GetComponent<BoxCollider>().enabled = true;
        faddingBtn.gameObject.SetActive(true);
    }

    public IEnumerator FadeOutBtn(Button faddingBtn)
    {
        faddingBtn.GetComponent<BoxCollider>().enabled = false;

        TMPro.TextMeshProUGUI textMeshPro = faddingBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        Color textColor = textMeshPro.color;
        Color btnColor = faddingBtn.image.color;

        for (float f = 0.8f; f >= -0.05f; f -= 0.05f)
        {
            textColor.a = f;
            textMeshPro.color = textColor;
            
            btnColor.a = f;
            faddingBtn.image.color = btnColor;

            yield return new WaitForSeconds(0.05f);
        }

        faddingBtn.gameObject.SetActive(false);
    }
}
