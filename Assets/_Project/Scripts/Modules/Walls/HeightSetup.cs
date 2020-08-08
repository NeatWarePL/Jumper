using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightSetup : Module
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetupMyHeight();
        }
    }

    private void Start()
    {
        SetupMyHeight();
    }

    public void SetupMyHeight()
    {
    }
}
