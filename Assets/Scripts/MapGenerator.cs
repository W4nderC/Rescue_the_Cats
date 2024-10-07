using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<Vector3> catsPosList = new List<Vector3>();
    [SerializeField] private float radius = 10f;
    [SerializeField] private SpawnableObjectScriptableObject spawnObj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < catsPosList.Count; i++)
        {
            print(catsPosList[i]);
            CreateCats(catsPosList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCats(Vector3 spawnPos) {
        float directionFacing = Random.Range (0f, 360f);


        Vector3 point = (Random.insideUnitSphere * radius);
        spawnPos = new Vector3(spawnPos.x + point.x, spawnPos.y, spawnPos.z + point.z);
        Instantiate (   
                        spawnObj.cats[Random.Range(0, spawnObj.cats.Length)], spawnPos, 
                        Quaternion.Euler (new Vector3 (0f, directionFacing, 0f))
                    );

    }
}
