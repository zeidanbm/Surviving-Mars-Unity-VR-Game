using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroNarrative : MonoBehaviour
{
    public Transform target;
    public AudioSource stormSound;

    void Update()
    {
        float step = 1.5f * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if(transform.position == target.position)
        {
            changeScene();
        }
    }

    void changeScene()
    {
        stormSound.Stop();
        SceneManager.LoadScene(2);
    }
}
