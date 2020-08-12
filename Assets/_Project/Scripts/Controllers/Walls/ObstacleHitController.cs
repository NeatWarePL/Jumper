using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitController : Module
{
    public List<GameObject> circles = new List<GameObject>();
    public List<GameObject> walls = new List<GameObject>();

    public static Action<GameObject> onCircleHit;
    public static Action<GameObject> onWallHit;

    private void OnEnable()
    {
        NW.Game.EventsProvider.onCircleSpawn += ManageCircleSpawn;
        NW.Game.EventsProvider.onWallSpawn += ManageWallSpawn;

        NW.Game.EventsProvider.onCircleHit += ManageCircleHit;
        NW.Game.EventsProvider.onWallHit += ManageWallHit;
    }

    private void OnDisable()
    {
        NW.Game.EventsProvider.onCircleSpawn -= ManageCircleSpawn;
        NW.Game.EventsProvider.onWallSpawn -= ManageWallSpawn;

        NW.Game.EventsProvider.onCircleHit -= ManageCircleHit;
        NW.Game.EventsProvider.onWallHit -= ManageWallHit;
    }

    private void ManageCircleSpawn(GameObject obj)
    {
        circles.Add(obj);
    }

    private void ManageWallSpawn(GameObject obj)
    {
        walls.Add(obj);
    }

    private void ManageCircleHit()
    {
        print("CIRCLE HIT");
        onCircleHit?.Invoke(circles[0]);
        circles.RemoveAt(0);
    }

    private void ManageWallHit()
    {
        walls.RemoveAt(0);
    }
}
