using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] MapGenerator mapGenerator;

    public List<Vector3> firstLvlVehiclePosList = new List<Vector3>();
    [SerializeField] private float vehicleSpawnRadius;
    [SerializeField] private GameObject worldVehicleObj;
    [SerializeField] private LayerMask vehicleLayerMask;
    public int rePositionAttempt;


    public void CreateVehicles(Vector3 spawnPos, GameObject[] spawnObj, int level)
    {
        Vector3 spawnPoint = RandomPosInSpawnArea( vehicleSpawnRadius, spawnPos);
        for (int i = 0; i < rePositionAttempt; i++)
        {
            if (!Physics.CheckSphere(spawnPoint, vehicleSpawnRadius, vehicleLayerMask)
            && IsInsideTheRoad(spawnPoint.x, spawnPoint.z))
            {
                GameObject vehicle = Instantiate
                (
                    spawnObj[Random.Range(0, 6 * level)], 
                    spawnPoint, 
                    Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
                );
                vehicle.transform.parent = worldVehicleObj.transform;

                return;
            } 
            else // recaculate new position  
            {
                spawnPoint = RandomPosInSpawnArea( vehicleSpawnRadius, spawnPoint);
            }
        }
    }

    private bool IsInsideTheRoad(float xAxis, float zAxis)
    {
        return xAxis >=0 && xAxis <= 100 && zAxis >= 50 && zAxis <= 400;
    }

    // random pos inside circle
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
