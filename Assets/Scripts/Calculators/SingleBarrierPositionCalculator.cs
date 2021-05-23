using UnityEngine;
using Assets.Scripts.Interfaces;

public class SingleBarrierPositionCalculator : MonoBehaviour, IPositionCalculator
{
    [SerializeField]
    LayerMask barrierLayer;

    public Vector3? GetNextSpawnPosition(float nextGroundSpawnPositionX)
    {
        Vector3? nextBarrierSpawnPosition = null;
        bool shouldSpawn = Physics.CheckSphere(transform.position, 0.5f, barrierLayer, QueryTriggerInteraction.Ignore);

        if (shouldSpawn)
        {
            nextBarrierSpawnPosition = GetSpawnPosition(nextGroundSpawnPositionX);
        }
        else
        {
            Debug.Log("Didnt spawn the tile bc other barrier is nearby");
        }

        return nextBarrierSpawnPosition;
    }

    private Vector3 GetSpawnPosition(float nextGroundSpawnPositionX)
    {
        var nextBarrierSpawnPosition = new Vector3
        {
            y = 0.5f
        };

        float randomZ = Random.Range(-1, 1);
        nextBarrierSpawnPosition.z = randomZ; // set a z position of the barrier
        nextBarrierSpawnPosition.x = Mathf.Round(nextGroundSpawnPositionX);

        return nextBarrierSpawnPosition;
    }
}
