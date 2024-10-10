using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject worldTerrain;
    [SerializeField] private GameObject[] terrainPrefabs;

    public void CreateTerrain(int mapIndex)
    {
        GameObject terrain = Instantiate
                                (
                                    terrainPrefabs[mapIndex], 
                                    worldTerrain.transform.position, 
                                    Quaternion.identity
                                );
        terrain.transform.parent = worldTerrain.transform;
    }
}
