using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static event EventHandler OnAnyCatTouched;
    // [HideInInspector] public Transform player;
    [HideInInspector] public Player player;
    [HideInInspector] public bool isFollow;
    [HideInInspector] public float followSpd;

    private float rotateSpd = 20;
    private Vector3 point;
    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        point = (UnityEngine.Random.insideUnitSphere * 9f);
        isFollow = false;

        col = gameObject.GetComponent<BoxCollider>();
        col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollow)
        {
            transform.position = Vector3.MoveTowards
            (
                transform.position, new Vector3
                (
                    // player.position.x + point.x,
                    // player.position.y,
                    // player.position.z + point.z
                    player.transform.position.x + point.x,
                    player.transform.position.y,
                    player.transform.position.z + point.z
                ), 
                Time.deltaTime * (followSpd - 1)
            );

            Vector3 newDirection = Vector3.RotateTowards
            (
                transform.forward,
                player.transform.position - transform.position,
                rotateSpd * Time.deltaTime,
                0
            );

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

    }

    public void IncreaseCatNum () 
    {
        GameManager.Instance.savedCatNum += 1;
        col.enabled = false;
    }

    public void InvokeOnAnyCatTouched()
    {
        OnAnyCatTouched?.Invoke(this, EventArgs.Empty);
    }
}
