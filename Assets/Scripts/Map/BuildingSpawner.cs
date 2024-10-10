using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] MapGenerator mapGenerator;

    [SerializeField] private float buildingSpawnRadius = 7f;
    [SerializeField] private GameObject worldBuildingObj;
    [SerializeField] private LayerMask buildingLayerMask;

    public void CreateBuildings(Vector3 spawnPos, GameObject[] spawnObj, int level)
    {
        GameObject building = Instantiate
        (
            spawnObj[Random.Range(0, level + 1)], 
            mapGenerator.RandomPosInSpawnArea( buildingSpawnRadius, spawnPos), 
            Quaternion.Euler (new Vector3 (0f, mapGenerator.RandomAgle(), 0f))
        );
        building.transform.parent = worldBuildingObj.transform;

        mapGenerator.RespawnNewPos(mapGenerator.rePositionBuildingAttempt, building, buildingLayerMask, 40f);
        
    }
}
