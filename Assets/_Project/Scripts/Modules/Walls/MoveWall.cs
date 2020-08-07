using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : Module
{
    private Transform target;

    private void OnEnable()
    {
        if (target == null)
        {
            target = NW.Game.EventsProvider.player;
        }
        MoveMe(target.position.x + gameConfig.wallsRange);
    }

    public void MoveMe(float posX)
    {
        myEntityTransform.position = new Vector3(posX, myEntityTransform.position.y, target.position.z);
    }
}