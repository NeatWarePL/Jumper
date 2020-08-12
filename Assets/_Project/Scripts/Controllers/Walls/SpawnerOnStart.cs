using UnityEngine;

public class SpawnerOnStart : Module
{
    public GameObject wallPrefab;
    public GameObject circlePrefab;
    private Transform target;

    private int beatsAfterWallCreated;

    private void OnEnable()
    {
        NW.EventsProvider.onSongDataChanged += SpawnStartingWalls;
    }

    private void OnDisable()
    {
        NW.EventsProvider.onSongDataChanged -= SpawnStartingWalls;
    }

    private void Start()
    {
        if (target == null)
        {
            target = NW.Game.EventsProvider.player;
        }
    }

    private void SpawnStartingWalls(SongData songData)
    {
        BeatData data = songData.beatsData[0];
        if (songData.beatsData.Length > gameConfig.numberOfWallsSpawnedAheadOfPlayer)
        {
            for (int i = 1; i < gameConfig.numberOfWallsSpawnedAheadOfPlayer; i++)
            {
                beatsAfterWallCreated++;
                if (/*i % 2 == 0 &&*/ beatsAfterWallCreated != gameConfig.beatsBeforeJump + 1 && beatsAfterWallCreated != 1 && beatsAfterWallCreated != 0)
                {
                    float xPos = target.position.x + (data.GetTimeToFollowingBeat(data, i) * gameConfig.playerSpeedOnDoTween);
                    float randomZ = UnityEngine.Random.Range(-gameConfig.randomizedRangeForXPositionObstacles, gameConfig.randomizedRangeForXPositionObstacles);
                    Vector3 circlePos = new Vector3(xPos - 0f, -7.15f, target.position.z + randomZ);
                    GameObject newCircle = Instantiate(circlePrefab, circlePos, Quaternion.identity);
                    NW.Game.EventsProvider.onCircleSpawn?.Invoke(newCircle);
                }
                if (beatsAfterWallCreated == gameConfig.beatsBeforeJump + 1)
                {
                    beatsAfterWallCreated = 0;

                }
                if (beatsAfterWallCreated == 2 && 1 != 2)
                {
                    float randomZ = UnityEngine.Random.Range(-gameConfig.randomizedRangeForXPositionObstacles, gameConfig.randomizedRangeForXPositionObstacles);
                    float getSomething = data.GetTimeToFollowingBeat(data, gameConfig.numberOfWallsSpawnedAheadOfPlayer) - data.GetTimeToFollowingBeat(data, gameConfig.numberOfWallsSpawnedAheadOfPlayer - 1);
                    float xPos = target.position.x + ((data.GetTimeToFollowingBeat(data, i) - (getSomething * 1f)) * gameConfig.playerSpeedOnDoTween);
                    Vector3 wallPos = new Vector3(xPos - 0f, 0f, target.position.z + randomZ);
                    GameObject newWall = Instantiate(wallPrefab, wallPos, Quaternion.identity);
                    NW.Game.EventsProvider.onWallSpawn?.Invoke(newWall);
                }
            }
        }

    }
}
