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

    // outside the road
    private Vector3 RandomOutsidePos(float min, float max)
    {   
        // spawn obj outside the road

        float xAxis = RandomFloatNum(-300, 400);
        if (xAxis >= min && xAxis <= max) // if x axis in side the road
        {
            if (xAxis <=50)
            {
                return new Vector3 // move to the leftside of the road
                (
                    xAxis - 170,
                    .5f, 
                    RandomFloatNum(150, 1200)
                );
            } 
            else 
            {
                return new Vector3 // move to the rightside of the road
                (
                    xAxis + 170,
                    .5f, 
                    RandomFloatNum(150, 1200)
                );
            }
        }
        else{
            return new Vector3
            (
                xAxis,
                .5f, 
                RandomFloatNum(150, 1200)
            );
        } 
    }

    // inside the road
    private Vector3 RandomInsidePos(float xMix, float xMax, float zMin = 90, float zMax = 1500)
    {   
            return new Vector3
            (
                RandomFloatNum(xMix, xMax),
                .5f, 
                RandomFloatNum(zMin, zMax)
            );
    }

    public void CreateLevel(int level)
    {
        // change cats pos randomly
        RandomCatPos();

        if (level < 4 && level >= 2)
        {
            CreateMap(level, 0, level, treeAmount, 1);
        }
        else if (level < 7 && level >= 4)
        {
            CreateMap(level, 1, 7, treeAmount, 2);
        }
        else
        {
            CreateMap(level, 2, 9, treeAmount, 3);

        }
    }

    private void CreateMap
    (
        int level, 
        int terrainIndex, 
        int buildingSpawnNum, 
        int treeAmount, 
        int vehicleAmount
    )
    {
        terrainSpawner.CreateTerrain(terrainIndex); // map 1 
        // spawn cats and vehicle surround it
        for (int i = 0; i < 5; i++)
        {
            catSpawner.CreateCats(catSpawner.catsPosList[i], spawnObj.cats);
            vehicleSpawner.CreateVehicles(catSpawner.catsPosList[i], spawnObj.vehicles, 1);
        }

        // spawn building
        for(int i = 0; i < buildingSpawnNum; i++) {
            buildingSpawner.CreateBuildings(RandomOutsidePos(-150, 250), spawnObj.building, level);
        }

        // spawn trees
        for(int i = 0; i < treeAmount + level; i++) {
            treeSpawner.CreateTrees(RandomOutsidePos(-20, 120), spawnObj.trees);
        }

        // spawn vehicles
        for (int i = 0; i < level + vehicleAmount; i++)
        {
            vehicleSpawner.CreateVehicles(RandomInsidePos(0, 100, 90, 370), spawnObj.vehicles, 1);
        }
    }

}
