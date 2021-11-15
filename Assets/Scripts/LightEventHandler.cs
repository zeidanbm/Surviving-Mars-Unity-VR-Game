using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventHandler : MonoBehaviour
{
    public float initialLightIntensity = 1f;
    public Material darkMaterial;
    public Material lightMaterial;

    private bool isLightOn = true;

    void Start()
    {
        LightController.LightSwitch += handleLightSwitch;
    }

    void handleLightSwitch()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Light>().intensity > 0)
            {
                child.gameObject.GetComponent<Light>().intensity = 0f;
                isLightOn = false;
            }
            else
            {
                child.gameObject.GetComponent<Light>().intensity = initialLightIntensity;
                isLightOn = true;
            }
        }

        if(isLightOn)
        {
            gameObject.GetComponent<MeshRenderer>().material = lightMaterial;
        } else
        {
            gameObject.GetComponent<MeshRenderer>().material = darkMaterial;
        }
        


    }
}
