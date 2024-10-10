using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public List<Vector3> firstLvlTreePosList = new List<Vector3>();
    [SerializeField] private float treeSpawnRadius = 7f;
    [SerializeField] private GameObject worldTreeObj;
    [SerializeField] private LayerMask treeLayerMask;
    

    [SerializeField] private MapGenerator mapGenerator;

    public void CreateTrees(Vector3 spawnPos, GameObject[] spawnObj)
    {
        GameObject tree = Instantiate
        (
            spawnObj[mapGenerator.RandomNumArray(spawnObj)], 
            mapGenerator.RandomPosInSpawnArea( treeSpawnRadius, spawnPos), 
            Quaternion.Euler (new Vector3 (0f, mapGenerator.RandomAgle(), 0f))
        );
        tree.transform.parent = worldTreeObj.transform;

        mapGenerator.RespawnNewPos(mapGenerator.rePositionTreeAttempt, tree, treeLayerMask);
        
    }
}
