using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Author(s): Daniel J. Garcia
public class OverworldMovement : MonoBehaviour

{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Rigidbody2D PlayerRB;
    private Vector2 movementDirection;

    public float getmovementSpeed()
    {
        return movementSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
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
        PlayerRB.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }
}
