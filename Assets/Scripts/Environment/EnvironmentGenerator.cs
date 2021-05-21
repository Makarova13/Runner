using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Transform> groundTiles;
    [SerializeField]
    private GameObject barrier;

    private Vector3 nextGroundSpawnPosition;
    private Vector3 nextBarrierSpawnPosition;

    void Start()
    {
        nextGroundSpawnPosition.x = 13; // start position is 10 because previous tiles were generated manualy

        StartCoroutine(SpawnTiles());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(1f * Time.deltaTime); //wait a second before spawning tiles
        PlaceNewGroundTiles();

        if(Random.Range(0, 5) == 0)
        {
            PlaceNewBarrierTiles();
        }

        StartCoroutine(SpawnTiles());
    }

    private void PlaceNewGroundTiles()
    {
        foreach (var tile in groundTiles)
        {
            Instantiate(tile, nextGroundSpawnPosition, tile.rotation); // spawn tiles
            nextGroundSpawnPosition.x += 0.5f; // calculate new position
        }
    }

    private void PlaceNewBarrierTiles()
    {
        var barrierTiles = barrier.GetComponentsInChildren<Transform>();
        
        int index = Random.Range(0, barrierTiles.Length - 1);
        var barrierTile = barrierTiles[index]; // take a random item from barriers list

        nextBarrierSpawnPosition = nextGroundSpawnPosition;

        float randomZ = Random.Range(-1, 1);
        nextBarrierSpawnPosition.z = randomZ; // set a z position of the barrier

        Instantiate(barrierTile, nextBarrierSpawnPosition, barrierTile.rotation); // spawn tiles
    }
}