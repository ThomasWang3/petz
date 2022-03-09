using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialChaseAI : MovementAI
{
    private float chaseSpeed = 2f;
    private float runSpeed = 6f;
    private float chaseRange = 8f;
    // Start is called before the first frame update
    void Start()
    {
        state = wander;
        movement = GetPlayerDirection();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        //if player is within normal detection range and moving, AI will run away
        if (distance < detectionRange && playerRB.velocity != Vector2.zero)
        {
            state = run;
            moveSpeed = runSpeed;
        }
        //if player is within AI chase detection range and not moving, AI will chase
        else if (distance < chaseRange && playerRB.velocity == Vector2.zero)
        {
            state = chase;
            moveSpeed = chaseSpeed;
        }
        else
        {
            state = rest;
        }
    }

    private void FixedUpdate()
    {
        if (state == run)
        {
            movement = GetPlayerDirection();
            AIMoveAway(movement);
        }
        else if (state == chase)
        {
            movement = GetPlayerDirection();
            AIMoveTowards(movement);
        }
    }
}
