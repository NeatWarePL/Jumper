using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Module
{
    private void Update()
    {
        myEntityTransform.Translate(new Vector3(gameConfig.playerSpeed, 0, 0));
    }
}
