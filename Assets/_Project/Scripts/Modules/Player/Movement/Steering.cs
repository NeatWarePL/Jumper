using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : Module
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SteerMe(new Vector3(0, 0, 0.5f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SteerMe(new Vector3(0, 0, -0.5f));
        }
    }

    private void SteerMe(Vector3 newMovement)
    {
        myEntityTransform.Translate(newMovement);
    }
}
