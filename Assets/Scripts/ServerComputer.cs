using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ServerComputer : MonoBehaviour
{
    public string enteredCode;
    public GameObject keypad;
    public GameObject door;
    public AudioSource doorOpenedSound;
    public AudioSource wrongCodeSound;
    public AudioSource AIreactivated;
    public GameObject conversationController;

    bool doorSoundPlayed;
    bool codeCorrect = false;
    bool canDisplayHumidityInstructions = false;


    void Start()
    {
        keypad.gameObject.SetActive(false);
        conversationController.GetComponent<ConversationController>().showText(Constants.TASK_ONE_START);
    }

    void Update()
    {
        if (enteredCode.Length == 4)
        {
            if (enteredCode == "3251")
            {
                door.gameObject.GetComponent<Door>().DoorSpeed = 3f;
                doorOpenedSound.Play();
                doorSoundPlayed = true;
                codeCorrect = true;
                conversationController.GetComponent<ConversationController>().showText(Constants.TASK_ONE_END1);
            }
            else
            {
                enteredCode = "";
                wrongCodeSound.Play();
            }

            keypad.gameObject.SetActive(false);
            enteredCode = "";
            Time.timeScale = 1;

        }

        if(!doorOpenedSound.isPlaying && doorSoundPlayed)
        {
            AIreactivated.Play();
            doorSoundPlayed = false;
            canDisplayHumidityInstructions = true;
        }

        if(!AIreactivated.isPlaying && canDisplayHumidityInstructions)
        {
            conversationController.GetComponent<ConversationController>().showText(Constants.TASK_ONE_END2);
            canDisplayHumidityInstructions = false;
        }
    }

    public void showKeypad()
    {
        if (!codeCorrect)
        {
            keypad.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void buttonClicked(Button btn)
    {
        string button = btn.name;
        enteredCode += button;
    }
}
