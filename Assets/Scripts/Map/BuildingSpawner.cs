using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] MapGenerator mapGenerator;

    [SerializeField] private float buildingSpawnRadius;
    [SerializeField] private GameObject worldBuildingObj;
    [SerializeField] private LayerMask buildingLayerMask;
    public int rePositionAttempt;

    public void CreateBuildings(Vector3 spawnPos, GameObject[] spawnObj, int level)
    {
        Vector3 spawnPoint = RandomPosInSpawnArea( buildingSpawnRadius, spawnPos);
        for (int i = 0; i < rePositionAttempt; i++)
        {
            if (!Physics.CheckSphere(spawnPoint, buildingSpawnRadius, buildingLayerMask)
            && !IsInsideTheRoad(spawnPoint.x, spawnPoint.z))
            {
                GameObject building = Instantiate
                (
                    spawnObj[Random.Range(0, level + 1)], 
                    spawnPoint, 
                    Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
                );
                building.transform.parent = worldBuildingObj.transform;   



                return;
            }
            else // recaculate new position  
            {
                spawnPoint = RandomPosInSpawnArea( buildingSpawnRadius, spawnPoint);
            }   
        }
    }

    private bool IsInsideTheRoad(float xAxis, float zAxis)
    {
        return xAxis >=-120 && xAxis <= 220 && zAxis >= 120 && zAxis <= 1350;
    }

    private Vector3 RandomPosInSpawnArea(float radius, Vector3 spawnPos)
    {
        Vector3 point = (Random.insideUnitSphere * radius);
        return new Vector3
        (
            spawnPos.x + point.x, 
            spawnPos.y, 
            spawnPos.z + point.z
        );
    }

    private float RandomAgle()
    {
        return Random.Range (0f, 360f);
    }
}
