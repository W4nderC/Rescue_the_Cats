using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] MapGenerator mapGenerator;

    public List<Vector3> firstLvlVehiclePosList = new List<Vector3>();
    [SerializeField] private float vehicleSpawnRadius = 7f;
    [SerializeField] private GameObject worldVehicleObj;
    [SerializeField] private LayerMask vehicleLayerMask;
    

    public void CreateVehicles(Vector3 spawnPos, GameObject[] spawnObj, int level)
    {
        GameObject vehicle = Instantiate
        (
            spawnObj[Random.Range(0, 6 * level)], 
            mapGenerator.RandomPosInSpawnArea( vehicleSpawnRadius, spawnPos), 
            Quaternion.Euler (new Vector3 (0f, mapGenerator.RandomAgle(), 0f))
        );
        vehicle.transform.parent = worldVehicleObj.transform;

        mapGenerator.RespawnNewPos(mapGenerator.rePositionVehicleAttempt, vehicle, vehicleLayerMask);

    }
}
