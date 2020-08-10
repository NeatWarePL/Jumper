using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dash : Module
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DashMe(myEntityTransform.position.x + gameConfig.dashRange * 100f, 0.2f);
        }
    }

    private void DashMe(float xPos, float time)
    {
        myEntityTransform.DOMoveX(xPos, time);
    }
}
