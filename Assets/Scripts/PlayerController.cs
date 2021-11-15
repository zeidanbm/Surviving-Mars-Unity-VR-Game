using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ProgressBar o2Bar;
    public Transform spawnPosition;
    public Transform spawnPosition2;
    public GameObject conversationController;

    private int o2Value = 100;
    private float MovementSpeed;

    private void Start()
    {
        MovementSpeed = PlayerPrefs.GetInt("playerSpeed") > 0 ? PlayerPrefs.GetInt("playerSpeed") : Constants.PLAYER_SPEED;
        transform.position = spawnPosition.position;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * Time.deltaTime * MovementSpeed;
        }

        if(o2Value == 0)
        {
            StopAllCoroutines();
            transform.position = spawnPosition2.position;
            o2Value = 100;
            conversationController.GetComponent<ConversationController>().showText(Constants.TASK_TWO_FAIL);
        }

        o2Bar.BarValue = o2Value;
    }

    public void restoreOxygen()
    {
        StopAllCoroutines();
        o2Value = 100;
    }

    public void startOxygenDepletion()
    {
        StartCoroutine("runOxygenDepletion");
    }

    IEnumerator runOxygenDepletion()
    {
        for(int i = o2Value; 0 < o2Value; i--)
        {
            o2Value = i;
            yield return new WaitForSeconds(1);
        }
    }
}
