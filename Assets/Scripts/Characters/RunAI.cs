using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Logan Mikulski
public class RunAI : MovementAI
{
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
        if (distance < detectionRange)
        {
            state = run;
        }
        else
        {
            state = wander;
        }
    }

    private void FixedUpdate()
    {
        if (state == run)
        {
            movement = GetPlayerDirection();
            AIMoveAway(movement);
        }
        //only updates wander direction if cooldown timer is up
        else if (state == wander && cooldownTime <= Time.time)
        {
            movement = GetRandDirection(movement);
            cooldownTime = Time.time + cooldownAdd;
        }
        //ensures AI will continue to move in wander direction
        else if (state == wander)
        {
            AIMoveAway(movement);
        }
    }
}
