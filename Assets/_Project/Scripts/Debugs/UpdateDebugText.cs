using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDebugText : Module
{
    public Text debugText;

    private void Update()
    {
        debugText.text = "BEATS BETWEEN JUMPS: " + gameConfig.beatsBetweenJumps;
    }
}
