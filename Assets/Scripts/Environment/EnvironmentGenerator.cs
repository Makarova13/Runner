using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform tile;

    private Vector3 nextSpawnPosition;

    void Start()
    {
        nextSpawnPosition.x = 1; // start position is 10 because previous tiles were generated manualy

        for (int i = 0; i < 10; i++)
        {
            PlaceNewTiles();
         }

        StartCoroutine(SpawnTiles());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(2f * Time.deltaTime); //wait a second before spawning tiles
        PlaceNewTiles();
        StartCoroutine(SpawnTiles());
    }

    private void PlaceNewTiles()
    {
        Instantiate(tile, nextSpawnPosition, tile.rotation); // spawn tiles
        nextSpawnPosition.x += 1; // calculate new position
    }
}
