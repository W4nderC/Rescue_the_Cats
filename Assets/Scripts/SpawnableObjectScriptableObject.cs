using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName  = "SpawnableObject", menuName = "ScriptableObject/SpawnableObject")]
public class SpawnableObjectScriptableObject : ScriptableObject
{
    public GameObject[] cats;
    public GameObject[] trees;
    public GameObject[] vehicles;
    public GameObject[] building;
    // public GameObject map;
}
