using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController
{
    public delegate void lightSwitch();
    public static event lightSwitch LightSwitch;

    public void onLightSwitch()
    {
        // switch on/off the lights
        LightSwitch();
    }
}
