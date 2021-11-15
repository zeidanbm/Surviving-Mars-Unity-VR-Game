using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _player.GetComponent<VRGaze>().VRGazeON();
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _player.GetComponent<VRGaze>().VRGazeOFF();
    }
}
