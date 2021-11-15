using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HumidityController : MonoBehaviour
{
    //public string enteredCode;
    public GameObject keypad;
    public AudioSource humidityRestoredSound;
    public int humidityValue = 21;
    public GameObject correctValue;
    public GameObject display;
    public GameObject levelTwoCutScene;

    private bool firstClose = true;

    void Start()
    {
        keypad.gameObject.SetActive(false);
    }

    void Update()
    {
        if (humidityValue == 33)
        {
            correctValue.gameObject.SetActive(true);
            humidityRestoredSound.Play();
            humidityValue = -500;
        }

        display.gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text = humidityValue.ToString() + "%";
    }

    public void showKeypad()
    {
        keypad.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeKeypad()
    {
        keypad.SetActive(false);
        Time.timeScale = 1;

        if(firstClose)
        {
            levelTwoCutScene.GetComponent<CutScene>().startCutScene();
            firstClose = false;
        }
    }

    public void buttonClicked(Button btn)
    {
        if(humidityValue != 33)
        {
            if (btn.name == "UpButton")
            {
                humidityValue = humidityValue + 1;
            }

            if (btn.name == "DownButton")
            {
                humidityValue = humidityValue - 1;
            }
        }
    }
}
