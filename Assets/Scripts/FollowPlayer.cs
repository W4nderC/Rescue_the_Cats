using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static event EventHandler OnAnyCatTouched;
    [HideInInspector] public Transform player;
    [HideInInspector] public bool isFollow;

    private float rotateSpd = 20;
    private Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        point = (UnityEngine.Random.insideUnitSphere * 9f);
        isFollow = false;

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
                    player.position.x + point.x,
                    player.position.y,
                    player.position.z + point.z
                ), 
                Time.deltaTime * 15f
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

    public void InvokeOnAnyCatTouched()
    {
        OnAnyCatTouched?.Invoke(this, EventArgs.Empty);
    }
}
