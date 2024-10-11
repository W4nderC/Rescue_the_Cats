using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public List<Vector3> firstLvlTreePosList = new List<Vector3>();
    [SerializeField] private float treeSpawnRadius;
    [SerializeField] private GameObject worldTreeObj;
    [SerializeField] private LayerMask treeLayerMask;
    public int rePositionAttempt;
    

    [SerializeField] private MapGenerator mapGenerator;

    public void CreateTrees(Vector3 spawnPos, GameObject[] spawnObj)
    {
        Vector3 spawnPoint = RandomPosInSpawnArea( treeSpawnRadius, spawnPos);
        for (int i = 0; i < rePositionAttempt; i++)
        {
            if (!Physics.CheckSphere(spawnPoint, treeSpawnRadius, treeLayerMask)
            && !IsInsideTheRoad(spawnPoint.x, spawnPoint.z))
            {
                GameObject tree = Instantiate
                (
                    spawnObj[Random.Range(0, spawnObj.Length)], 
                    spawnPoint, 
                    Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
                );
                tree.transform.parent = worldTreeObj.transform;

                return;
            }
            else // recaculate new position  
            {
                spawnPoint = RandomPosInSpawnArea( treeSpawnRadius, spawnPoint);
            }
        }
        // mapGenerator.RespawnNewPos(mapGenerator.rePositionTreeAttempt, tree, treeLayerMask);
    }

    private bool IsInsideTheRoad(float xAxis, float zAxis)
    {
        return xAxis >=-50 && xAxis <= 150 && zAxis >= 50 && zAxis <= 1500;
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
