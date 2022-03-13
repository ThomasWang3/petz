using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Mike Xu

public class camera_tracker : MonoBehaviour
{

    public Vector2 trackingvect;
    private Vector3 offset;
    public Transform player_location;
    public float update_rate = 50;
    void Start()
    {
        offset = (Vector3)trackingvect;
        offset.z = transform.position.z - player_location.position.z;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player_location.position+offset, update_rate * Time.deltaTime);
    }
}
