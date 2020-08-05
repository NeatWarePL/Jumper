using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallsSpawner : Module
{
    public GameObject wallPrefab;
    public List<GameObject> currentWalls = new List<GameObject>();
    public static int currentWallsCount;
    int smash = 0;

    private void Start()
    {
        NW.Game.EventsProvider.onSmash += PlayerSmashCallback;
        SpawnWalls();
    }

    public void SpawnWalls()
    {
        while (currentWalls.Count < gameConfig.wallsCount)
        {
            GameObject newWall = Instantiate(wallPrefab, transform);
            currentWalls.Add(newWall);
            currentWallsCount++;
        }
    }

    public void PlayerSmashCallback()
    {
        smash++;
        RemoveLastWall();
    }

    private void RemoveLastWall()
    {
        if (smash >= 3)
        {
            Destroy(currentWalls[0]);
            currentWalls.RemoveAt(0);
        }
        currentWallsCount--;
        SpawnWalls();
    }
}