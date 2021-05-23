using System.Collections;
using UnityEngine;
using Assets.Scripts.Common;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField]
    LayerMask barrierLayer;
    [SerializeField]
    private Transform ground;
    [SerializeField]
    private GameObject barrier;
    [SerializeField]
    private Transform mushroom;

    private Vector3 nextGroundSpawnPosition;
    private Vector3 nextBarrierSpawnPosition;
    private Transform[] barrierTiles;
    private float waitTime = 1f;
    private int tilesWithMushrommsCount = 0;

    void Start()
    {
        nextGroundSpawnPosition.x = 13; // start position is 10 because previous tiles were generated manualy
        barrierTiles = barrier.GetComponentsInChildren<Transform>();

        StartCoroutine(SpawnTiles());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(waitTime * Time.deltaTime); //wait a second before spawning tiles
        PlaceNewGroundTiles();

        if(Random.Range(0, 10) == 0)
        {
            PlaceNewBarrierTiles();
        }

        if(tilesWithMushrommsCount > 3)
        {
            PlaceNewMushroomTiles();
            tilesWithMushrommsCount = 0;
        }

        waitTime = waitTime > Constants.MinWaitTime ? waitTime - GameManager.Instance.Player.RunSpeed * Constants.RunningAccelaration * Time.deltaTime : waitTime;
        tilesWithMushrommsCount++;
        StartCoroutine(SpawnTiles());
    }

    private void PlaceNewGroundTiles()
    {
        Instantiate(ground, nextGroundSpawnPosition, ground.rotation); // spawn tiles
        nextGroundSpawnPosition.x += 0.5f; // calculate new position
    }

    private void PlaceNewBarrierTiles()
    {
        int index = Random.Range(0, barrierTiles.Length - 1);
        var barrierTile = barrierTiles[index]; // take a random item from barriers list

        nextBarrierSpawnPosition = nextGroundSpawnPosition;

        float randomZ = Random.Range(-1, 1);
        nextBarrierSpawnPosition.z = randomZ; // set a z position of the barrier

        bool shouldSpawn = !Physics.CheckSphere(nextBarrierSpawnPosition, 2f, barrierLayer, QueryTriggerInteraction.Collide);

        if (shouldSpawn)
        {
            Instantiate(barrierTile, nextBarrierSpawnPosition, barrierTile.rotation); // spawn tiles
        }
    }

    private void PlaceNewMushroomTiles()
    {
        float randZ = Random.Range(-1, 1);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(mushroom, new Vector3(nextGroundSpawnPosition.x, 0.5f, randZ), mushroom.rotation); // spawn tiles
        }
    }
}