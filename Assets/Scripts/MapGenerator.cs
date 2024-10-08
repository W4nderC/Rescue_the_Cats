using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance { get; private set; }

    [SerializeField] private List<Vector3> catsPosList = new List<Vector3>();
    [SerializeField] private List<Vector3> firstLvlTreePosList = new List<Vector3>();
    [SerializeField] private float catSpawnRadius = 10f;
    [SerializeField] private float treeSpawnRadius = 10f;
    [SerializeField] private float vehicleSpawnRadius = 10f;
    [SerializeField] private SpawnableObjectScriptableObject spawnObj;

    [SerializeField] private GameObject worldCatObj;
    [SerializeField] private GameObject worldTreeObj;
    [SerializeField] private GameObject worldVehicleObj;

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

    void Start()
    {
        // for (int i = 0; i < catsPosList.Count; i++)
        // {
        //     CreateCats(catsPosList[i]);
        // }
    }

    private void CreateCats(Vector3 spawnPos) {

        spawnPos = RandomPosInSpawnArea(catSpawnRadius, spawnPos);

        GameObject cat = Instantiate 
                    (   
                        spawnObj.cats[RandomNumArray(spawnObj.cats)], spawnPos, 
                        Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
                    );

        cat.transform.parent = worldCatObj.transform;

        // spawn vehicle surround a cat
        CreateVehicles(cat.transform.position);
    }

    private void CreateTrees(Vector3 spawnPos)
    {
        GameObject tree = Instantiate
        (
            spawnObj.trees[RandomNumArray(spawnObj.trees)], 
            RandomPosInSpawnArea( treeSpawnRadius, spawnPos), 
            Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
        );
        tree.transform.parent = worldTreeObj.transform;
    }

    private void CreateVehicles(Vector3 spawnPos)
    {
        GameObject vehicle = Instantiate
        (
            spawnObj.vehicles[RandomNumArray(spawnObj.vehicles)], 
            RandomPosInSpawnArea( vehicleSpawnRadius, spawnPos), 
            Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
        );
        vehicle.transform.parent = worldVehicleObj.transform;
    }

    private int RandomNumArray(GameObject[] objArray)
    {
        return Random.Range(0, objArray.Length);
    }

    private float RandomAgle()
    {
        return Random.Range (0f, 360f);
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

    public void FirstLevel()
    {
        for (int i = 0; i < catsPosList.Count; i++)
        {
            CreateCats(catsPosList[i]);
        }

        for (int i = 0; i < firstLvlTreePosList.Count; i++)
        {
            CreateTrees(firstLvlTreePosList[i]);
        }
    }
}
