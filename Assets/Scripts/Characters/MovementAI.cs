using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Mike Xu, Logan Mikulski
public class MovementAI : MonoBehaviour 
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Rigidbody2D playerRB;
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected float distance;
    [SerializeField] protected float detectionRange = 5f;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Vector2 movement;
    [SerializeField] protected float randDiff = 5f;
    [SerializeField] protected double cooldownTime = 0;
    [SerializeField] protected double cooldownAdd = 1;
    protected string state;
    protected string rest = "rest";
    protected string chase = "chase";
    protected string run = "run";
    protected string wander = "wander";

    protected Vector2 GetPlayerDirection()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        return direction;
    }

    protected void AIMoveTowards(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    protected void AIMoveAway(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position - (direction * moveSpeed * Time.deltaTime));
    }

    //provides a random direction based on the provided direction
    protected Vector2 GetRandDirection(Vector2 direction)
    {
        Vector2 randDirection;
        randDirection.x = Random.Range(direction.x - randDiff, direction.x + randDiff);
        randDirection.y = Random.Range(direction.y - randDiff, direction.y + randDiff);
        return randDirection;
    }
}