using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private VehicleSpawner vehicleSpawner;

    public List<Vector3> catsPosList = new List<Vector3>();
    [SerializeField] private float catSpawnRadius = 3f;
    [SerializeField] private GameObject worldCatObj;

    public void CreateCats(Vector3 spawnPos, GameObject[] spawnObj) {

        spawnPos = mapGenerator.RandomPosInSpawnArea(catSpawnRadius, spawnPos);

        GameObject cat = Instantiate 
                    (   
                        spawnObj[mapGenerator.RandomNumArray(spawnObj)], spawnPos, 
                        Quaternion.Euler (new Vector3 (0f, mapGenerator.RandomAgle(), 0f))
                    );

        cat.transform.parent = worldCatObj.transform;

        // spawn vehicle surround a cat
        // vehicleSpawner.CreateVehicles(cat.transform.position, mapGenerator.spawnObj.vehicles, 1);
    }
}
