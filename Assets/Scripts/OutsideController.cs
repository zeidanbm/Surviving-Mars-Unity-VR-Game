using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideController : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(player.transform.position.x > 94.5)
        {
            player.GetComponent<PlayerController>().startOxygenDepletion();
        } else
        {
            player.GetComponent<PlayerController>().restoreOxygen();
        }
    }
}
