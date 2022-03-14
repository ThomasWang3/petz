using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author(s): Daniel J. Garcia
public class OverworldMovement : MonoBehaviour

{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Rigidbody2D playerRB;
    [SerializeField] protected BoxCollider2D playerBC;
    [SerializeField] private EnemyManager em;
    private Vector2 movementDirection;
    [SerializeField] protected LevelManager lm;

    public float getmovementSpeed()
    {
        return movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        // if the player comes into contact with an enemy, load 1p scene
    }

    private void FixedUpdate()
    {
        moveCharacter();
    }

    void getInput()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(movementX, movementY).normalized;
    }

    void moveCharacter()
    {
        playerRB.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer >= 6 && collision.gameObject.layer < 10) {
            //Debug.Log("Enemy Collision");
            //Debug.Log("collision.gameObject.layer = " + collision.gameObject.layer);
            if (collision.gameObject.layer >= 6)
            {
                int temp = collision.gameObject.layer - 6;
                //Debug.Log("collision.gameObject.layer = " + temp);
                //Debug.Log("enemies " + em.enemies[0]);
                em.ReduceEnemyCount(temp);
            }
            //em.ReduceEnemyCount(collision.gameObject.tag == "PunkKid");
            lm.LoadLevelWithIndex(collision.gameObject.layer - 4);
            //Debug.Log("Enemy Collision end");
        } else if(collision.gameObject.layer == 10) {
            lm.LoadMainMenu();
        }
    }
}
