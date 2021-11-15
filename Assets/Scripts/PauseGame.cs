using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public Transform pauseMenuAttachPoint;
    public Transform pauseButtonAttachPoint;
    public Transform _player;

    private void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.gameObject.transform.position = pauseButtonAttachPoint.position;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseMenu.gameObject.transform.position = pauseMenuAttachPoint.position;
        pauseMenu.gameObject.transform.rotation = pauseMenuAttachPoint.transform.rotation;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


}
