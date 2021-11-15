using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorController : MonoBehaviour, IInteractableObject
{
    public GameObject GeneratorSparks;
    private LightController _lightController;
    public GameObject conversationController;

    private void Start()
    {
        _lightController = new LightController();
    }

    public void activateObject()
    {
        GeneratorSparks.GetComponent<ParticleSystem>().Stop();
        _lightController.onLightSwitch();
        conversationController.GetComponent<ConversationController>().showText(Constants.TASK_TWO_END);
        Invoke("endGame", 4);
    }

    private void endGame()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
