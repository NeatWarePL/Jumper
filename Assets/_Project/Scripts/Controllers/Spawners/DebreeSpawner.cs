using NW;
using System.Collections;
using UnityEngine;

public class DebreeSpawner : Entity
{
    private Transform playerT;
    public GameObject debreePrefab;

    private void Start()
    {
        playerT = NW.Game.EventsProvider.player;
        EventsProvider.onSongDataChanged += StartSpawn;
    }
    private void OnDisable()
    {
        EventsProvider.onSongDataChanged -= StartSpawn;
    }

    private void StartSpawn(SongData newData)
    {
        StartCoroutine(SpawnDebree());
    }


    private IEnumerator SpawnDebree()
    {
        Transform newDebree = Instantiate(debreePrefab).transform;
        float xPos = playerT.position.x + 4000f;
        float zPos = playerT.position.z;
        newDebree.position = new Vector3(xPos, -20f, zPos);
        float randomizedTime = UnityEngine.Random.Range(1f, 4f);
        yield return new WaitForSeconds(randomizedTime);
        StartCoroutine(SpawnDebree());
    }
}
