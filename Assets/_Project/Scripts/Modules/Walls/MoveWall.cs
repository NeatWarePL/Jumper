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
        MoveMe();
    }

    public void MoveMe()
    {
        myEntityTransform.position = new Vector3(target.position.x + (gameConfig.playerSmashRange * 0.5f) + (gameConfig.playerSmashRange * WallsSpawner.currentWallsCount), myEntityTransform.position.y, target.position.z);
    }
}