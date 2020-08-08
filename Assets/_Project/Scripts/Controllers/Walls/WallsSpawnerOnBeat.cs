using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallsSpawnerOnBeat : Module
{
    public Wall wallPrefab;
    public List<GameObject> currentWalls = new List<GameObject>();
    public List<GameObject> brokenWalls = new List<GameObject>();

    private void OnEnable()
    {
        BeatManager.onWallCreate += SpawnWalls;
    }

    private void OnDisable()
    {
        BeatManager.onWallCreate -= SpawnWalls;
    }

    public virtual void SpawnWalls()
    {
        Wall newestWall = Instantiate(wallPrefab, transform);
        currentWalls.Add(newestWall.gameObject);
    }
}