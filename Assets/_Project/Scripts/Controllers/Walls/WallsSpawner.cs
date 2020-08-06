using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallsSpawner : Module
{
    public Wall wallPrefab;
    public List<GameObject> currentWalls = new List<GameObject>();
    public List<GameObject> brokenWalls = new List<GameObject>();
    public static int currentWallsCount;
    protected Wall newestWall;
    protected int smash = 0;

    protected virtual void Start()
    {
        BeatManager.onWallCreate += CreateWall;
        SpawnWalls();
    }

    public virtual void SpawnWalls()
    {
        while (currentWalls.Count < gameConfig.wallsCount)
        {
            newestWall = Instantiate(wallPrefab, transform);
            currentWalls.Add(newestWall.gameObject);
            currentWallsCount++;
        }
    }

    public virtual void CreateWall(float wallHeight)
    {
        smash++;
        RemoveLastWall();
        newestWall.SetupWallHeight(wallHeight);
    }

    protected virtual void RemoveLastWall()
    {
        brokenWalls.Add(currentWalls[0]);
        if (smash >= 3)
        {
            Destroy(currentWalls[0]);
            currentWalls.RemoveAt(0);
        }
        currentWallsCount--;
        SpawnWalls();
    }
}