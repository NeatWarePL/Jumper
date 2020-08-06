using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallsSpawner2 : WallsSpawner
{
    protected override void Start()
    {
        BeatManager.onWallCreate += CreateWall;
    }

    public override void SpawnWalls()
    {
    }

    public override void CreateWall(float wallHeight)
    {
        Instantiate(wallPrefab, transform);
    }

    protected override void RemoveLastWall()
    {
    }
}