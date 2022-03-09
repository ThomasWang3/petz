using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Mike Xu, Logan Mikulski
public class ChaseAI : MovementAI
{
    // Start is called before the first frame update
    void Start()
    {
        state = rest;
        movement = GetPlayerDirection();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance < detectionRange)
        {
            state = chase;
        }
        else
        {
            state = rest;
        }
    }

    private void FixedUpdate()
    {
        if (state == chase)
        {
            movement = GetPlayerDirection();
            AIMoveTowards(movement);
        }
    }
}