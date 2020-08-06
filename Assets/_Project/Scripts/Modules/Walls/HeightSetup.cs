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

    public void SetupMyHeight()
    {
        print("Updating my height");
        float height = 11f;
        myEntityTransform.position = new Vector3(myEntityTransform.position.x, height, myEntityTransform.position.z);
    }
}
