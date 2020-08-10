using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawnerTest : Module
{
    private Transform target;
    private int beatAfterCircleCreated = 2;

    public GameObject circlePrefab;
    public GameObject wallPrefab;
    public List<GameObject> currentWalls = new List<GameObject>();
    public List<GameObject> brokenWalls = new List<GameObject>();

    private void OnEnable()
    {
        BeatManager.onBeat += ManageSpawns;
    }

    private void OnDisable()
    {
        BeatManager.onBeat -= ManageSpawns;
    }

    private void Start()
    {
        if (target == null)
        {
            target = NW.Game.EventsProvider.player;
        }
    }

    public void ManageSpawns(BeatData beatData)
    {
        beatAfterCircleCreated++;
        print(beatAfterCircleCreated);
        if (beatAfterCircleCreated == gameConfig.beatsDuringJump - 1)
        {
            SpawnWallIfAble(beatData);
        }
        if (beatAfterCircleCreated == gameConfig.beatsBeforeJump + gameConfig.beatsDuringJump)
        {
            SpawnCircleIfAble(beatData);
        }
    }

    private void SpawnCircleIfAble(BeatData beatData)
    {
        beatAfterCircleCreated = 0;
        float xPos = target.position.x + (beatData.GetTimeToFollowingBeat(beatData, gameConfig.numberOfWallsSpawnedAheadOfPlayer) * gameConfig.playerSpeedOnDoTween);
        Vector3 circlePos = new Vector3(xPos - 20f, -7.15f, target.position.z);
        Instantiate(circlePrefab, circlePos, Quaternion.identity);
    }

    private void SpawnWallIfAble(BeatData beatData)
    {
        float xPos = target.position.x + (beatData.GetTimeToFollowingBeat(beatData, gameConfig.numberOfWallsSpawnedAheadOfPlayer) * gameConfig.playerSpeedOnDoTween);
        Vector3 wallPos = new Vector3(xPos - 20f, 0f, target.position.z);
        Instantiate(wallPrefab, wallPos, Quaternion.identity);
    }
}
