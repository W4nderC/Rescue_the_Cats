using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using Watermelon;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance { get; private set; }

    [SerializeField] private TreeSpawner treeSpawner;
    [SerializeField] private CatSpawner catSpawner;
    [SerializeField] private VehicleSpawner vehicleSpawner;
    [SerializeField] private BuildingSpawner buildingSpawner;
    [SerializeField] private TerrainSpawner terrainSpawner;
    
    public SpawnableObjectScriptableObject spawnObj;

    [SerializeField] private int treeAmount;
    public int rePositionVehicleAttempt;
    public int rePositionBuildingAttempt;
    public int rePositionTreeAttempt;

    private bool IsOutsideTheRoad = true;


    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }
    }

    public void RespawnNewPos(int loopAttempt, GameObject obj, LayerMask layerMask, float respawnRadius = 30f)
    {
        for (int i = 0; i < loopAttempt; i++)
        {
            // if this obj spawn in other obj pos
            if (Physics.CheckSphere(obj.transform.position, respawnRadius, layerMask))
            {
                if (i == rePositionVehicleAttempt - 1) //if can't find another empty pos at the end of the loop 
                {
                    Destroy(obj.gameObject);
                }
                else
                {
                    // move this obj to another random pos
                    obj.transform.position = RandomPosInSpawnArea(respawnRadius, obj.transform.position);
                }
            }
            else
            {
                return;
            }
        }
    }

    // random pos inside circle
    public Vector3 RandomPosInSpawnArea(float radius, Vector3 spawnPos)
    {
        Vector3 point = (Random.insideUnitSphere * radius);
        return new Vector3
        (
            spawnPos.x + point.x, 
            spawnPos.y, 
            spawnPos.z + point.z
        );
    }

    public int RandomNumArray(GameObject[] objArray)
    {
        return Random.Range(0, objArray.Length);
    }

    // public int RandomNumArray(GameObject[] objArray, int level)
    // {
    //     return Random.Range(0, 6 * level);
    // }

    public float RandomAgle()
    {
        return Random.Range (0f, 360f);
    }

    public float RandomFloatNum(float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    public void FirstLevel()
    {
        terrainSpawner.CreateTerrain(0);

        for (int i = 0; i < catSpawner.catsPosList.Count; i++)
        {
            catSpawner.CreateCats(catSpawner.catsPosList[i], spawnObj.cats);
        }

        for (int i = 0; i < treeSpawner.firstLvlTreePosList.Count; i++)
        {
            treeSpawner.CreateTrees(treeSpawner.firstLvlTreePosList[i], spawnObj.trees);
        }

        for (int i = 0; i < 6; i++)
        {
            vehicleSpawner.CreateVehicles(catSpawner.catsPosList[i], spawnObj.vehicles, 1);
        }
    }

    private void RandomCatPos()
    {
        for (int i = 0; i < catSpawner.catsPosList.Count; i++)
        {
            catSpawner.catsPosList[i] = new Vector3
            (
                RandomFloatNum(20, 80), 
                catSpawner.catsPosList[i].y, 
                catSpawner.catsPosList[i].z + RandomFloatNum(-10, 10)
            );
        }
    }

    private Vector3 RandomOtherPos(bool outsideTheRoad)
    {   
        
        if(outsideTheRoad) // spawn obj outside the road
        {
            float xAxis = RandomFloatNum(-200, 300);
            if (xAxis >= -20 && xAxis <= 120) // if x axis in side the road
            {
                if (xAxis <=50)
                {
                    return new Vector3 // move to the leftside of the road
                    (
                        xAxis + RandomFloatNum(-81, -101),
                        .5f, 
                        RandomFloatNum(10, 1540)
                    );
                } 
                else 
                {
                    return new Vector3 // move to the rightside of the road
                    (
                        xAxis + RandomFloatNum(81, 101),
                        .5f, 
                        RandomFloatNum(10, 1540)
                    );
                }
            }
            else{
                return new Vector3
                (
                    xAxis,
                    .5f, 
                    RandomFloatNum(10, 1540)
                );
            } 
        }
        else // spawn obj inside the road
        {
            float xAxis = RandomFloatNum(0, 100);

            return new Vector3
            (
                xAxis,
                .5f, 
                RandomFloatNum(90, 1540)
            );
        }
    }

    public void CreateLevel(int level)
    {
        if (level < 4 && level >= 2)
        {
            terrainSpawner.CreateTerrain(0); // map 1 
        }
        else if (level < 7 && level >= 4)
        {
            terrainSpawner.CreateTerrain(1); // map 2 
        }
        else
        {
            terrainSpawner.CreateTerrain(2); // map 3 
        }


        // change cats pos randomly
        RandomCatPos();

        // spawn cats
        for (int i = 0; i < 5; i++)
        {
            catSpawner.CreateCats(catSpawner.catsPosList[i], spawnObj.cats);
        }

        // spawn trees
        for(int i = 0; i < treeAmount + level; i++) {
            treeSpawner.CreateTrees(RandomOtherPos(IsOutsideTheRoad), spawnObj.trees);
        }

        for(int i = 0; i < level; i++) {
            buildingSpawner.CreateBuildings(RandomOtherPos(IsOutsideTheRoad), spawnObj.building, level);
        }
    }

}
