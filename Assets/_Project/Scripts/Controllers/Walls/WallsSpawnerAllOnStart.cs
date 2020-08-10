using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawnerAllOnStart : Module
{
    private Transform target;

    public Wall wallPrefab;
    public List<GameObject> currentWalls = new List<GameObject>();
    public List<GameObject> brokenWalls = new List<GameObject>();

    private void OnEnable()
    {
        NW.EventsProvider.onSongDataChanged += SpawnAllWalls;
    }

    private void OnDisable()
    {
        NW.EventsProvider.onSongDataChanged -= SpawnAllWalls;
    }

    private void Start()
    {
        if (target == null)
        {
            target = NW.Game.EventsProvider.player;
        }
    }

    int kiszka = 0;

    public void SpawnAllWalls(SongData songData)
    {
        for (int i = 0; i < songData.beatsData.Length; i++)
        {
            kiszka++;
            if (kiszka == gameConfig.beatsBeforeJump + gameConfig.beatsDuringJump)
            {
                kiszka = 0;
                Wall newestWall = Instantiate(wallPrefab, transform);
                newestWall.transform.position = new Vector3(target.position.x + (songData.beatsData[i].timestamp * 59.4f) + 31.5f, wallPrefab.transform.position.y, wallPrefab.transform.position.z);
                currentWalls.Add(newestWall.gameObject);
            }
        }
    }
}
