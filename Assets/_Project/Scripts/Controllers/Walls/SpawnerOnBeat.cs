using System.Collections.Generic;
using UnityEngine;

public class SpawnerOnBeat : Module
{
    private Vector3 playerStartingPosition;
    private Transform target;
    private int beatsAfterWallCreated = 4;

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
        playerStartingPosition = target.position;
    }

    public void ManageSpawns(BeatData beatData)
    {
        beatsAfterWallCreated++;
        if (beatsAfterWallCreated == gameConfig.beatsBeforeJump + 2)
        {
            SpawnWallIfAble(beatData);
        }
        //if (beatsAfterWallCreated % 2 == 1)
        {
            if (beatsAfterWallCreated != 0 && beatsAfterWallCreated != gameConfig.beatsBeforeJump + 1 && beatsAfterWallCreated != 0)
            {
                SpawnCircleIfAble(beatData);
            }
        }
    }

    private void SpawnCircleIfAble(BeatData beatData)
    {
        float randomZ = UnityEngine.Random.Range(-gameConfig.randomizedRangeForXPositionObstacles, gameConfig.randomizedRangeForXPositionObstacles);
        float xPos = target.position.x + ((beatData.GetTimeToFollowingBeat(beatData, gameConfig.numberOfWallsSpawnedAheadOfPlayer)) * gameConfig.playerSpeedOnDoTween);
        Vector3 circlePos = new Vector3(xPos - 20f, -7.15f, playerStartingPosition.z + randomZ);
        GameObject newCircle = Instantiate(circlePrefab, circlePos, Quaternion.identity);
        NW.Game.EventsProvider.onCircleSpawn?.Invoke(newCircle);
    }

    private void SpawnWallIfAble(BeatData beatData)
    {
        float randomZ = UnityEngine.Random.Range(-gameConfig.randomizedRangeForXPositionObstacles, gameConfig.randomizedRangeForXPositionObstacles);
        beatsAfterWallCreated = 0;
        float getSomething = beatData.GetTimeToFollowingBeat(beatData, gameConfig.numberOfWallsSpawnedAheadOfPlayer) - beatData.GetTimeToFollowingBeat(beatData, gameConfig.numberOfWallsSpawnedAheadOfPlayer - 1);
        float xPos = target.position.x + ((beatData.GetTimeToFollowingBeat(beatData, gameConfig.numberOfWallsSpawnedAheadOfPlayer) - (getSomething * 1f)) * gameConfig.playerSpeedOnDoTween);
        Vector3 wallPos = new Vector3(xPos - 20f, 0f, playerStartingPosition.z + randomZ);
        GameObject newWall = Instantiate(wallPrefab, wallPos, Quaternion.identity);
        NW.Game.EventsProvider.onWallSpawn?.Invoke(newWall);
    }
}
