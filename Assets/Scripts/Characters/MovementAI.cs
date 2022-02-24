using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Mike Xu
public class MovementAI : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float distance = 3f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    // Start is called before the first frame update
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction) {
        if (distance < detectionRange) {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
}