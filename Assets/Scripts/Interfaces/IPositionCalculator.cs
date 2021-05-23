using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IPositionCalculator
    {
        Vector3? GetNextSpawnPosition(float nextGroundSpawnPositionX);
    }
}
