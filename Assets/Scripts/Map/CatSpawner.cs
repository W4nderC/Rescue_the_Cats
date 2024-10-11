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

        spawnPos = RandomPosInSpawnArea(catSpawnRadius, spawnPos);

        GameObject cat = Instantiate 
                    (   
                        spawnObj[Random.Range(0, spawnObj.Length)], 
                        spawnPos, 
                        Quaternion.Euler (new Vector3 (0f, RandomAgle(), 0f))
                    );

        cat.transform.parent = worldCatObj.transform;

        // spawn vehicle surround a cat
        // vehicleSpawner.CreateVehicles(cat.transform.position, mapGenerator.spawnObj.vehicles, 1);
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
