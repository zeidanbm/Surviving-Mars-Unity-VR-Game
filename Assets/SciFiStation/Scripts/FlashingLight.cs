using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{


    [SerializeField] Light LightSource ;
    [SerializeField] float FlashSpeed = .2f;

    float counter = 0f;
    //float currentSpeed = 30f;
    bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // currentSpeed = FlashSpeed * Time.deltaTime;

        counter += 1f * Time.deltaTime;

        if (counter > FlashSpeed)
        {
            counter = 0f;
            isOn = !isOn;
        
        }

        LightSource.enabled = isOn;


    }
}
