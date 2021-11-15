using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject sceneCam;
    public AudioSource powerShutDownAudio;
    public AudioSource powerShutDownAIVoice;
    public GameObject generatorSparks;
    public GameObject conversationController;

    private LightController _lightController;

    public void startCutScene()
    {
        _lightController = new LightController();

        mainCam.SetActive(false);
        sceneCam.SetActive(true);
        sceneCam.GetComponent<Animation>().Play();
        StartCoroutine(runCutScene());
    }

    IEnumerator runCutScene()
    {
        yield return new WaitForSeconds(1);
        powerShutDownAudio.Play();
        generatorSparks.SetActive(true);
        powerShutDownAIVoice.Play();
        yield return new WaitForSeconds(2);
        _lightController.onLightSwitch();
        yield return new WaitForSeconds(5);
        sceneCam.SetActive(false);
        mainCam.SetActive(true);
        yield return new WaitForSeconds(1);
        conversationController.GetComponent<ConversationController>().showText(Constants.TASK_TWO_START);
        //Destroy(_lightController);
    }
}
