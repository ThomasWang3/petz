using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Thomas Wang
// Create a new class to facilitate multiplayer input
// Call methods from CombatManager and have it take care of the game logic
public class InputManager : MonoBehaviour {
    [SerializeField] CombatManager cm;

    // Controls
    // P1 Pet Controls (w - previous, s - next)
    [SerializeField] private KeyCode p1PrevKey;
    [SerializeField] private KeyCode p1NextKey;

    // P1 Attack Controls (space - attack)
    [SerializeField] private KeyCode p1AttackKey;

    // P2 Human Controls (up - previous, down - next)
    [SerializeField] private KeyCode p2PrevKey;
    [SerializeField] private KeyCode p2NextKey;

    // P2 Attack Controls (rightshift - attack)
    [SerializeField] private KeyCode p2AttackKey;
    

    // Update is called once per frame
    void Update() {
        if (!cm.getIsPaused() && !cm.getisAttacking()) {
            if (cm.getP1Turn()) {
                // If it's player 1's turn, take in input for P1
                if (Input.GetKeyDown(p1PrevKey)) {
                    cm.PreviousPet();
                } else
                    if (Input.GetKeyDown(p1NextKey)) {
                    cm.NextPet();
                } else
                    if (Input.GetKeyDown(p1AttackKey)) {
                    StartCoroutine(cm.PetAttack());
                }
            } else {
                // if it's player 2's turn (not player 1's turn), take in input for P2
                if (Input.GetKeyDown(p2PrevKey)) {
                    cm.PreviousHuman();
                } else
                    if (Input.GetKeyDown(p2NextKey)) {
                    cm.NextHuman();
                } else
                    if (Input.GetKeyDown(p2AttackKey)) {
                    StartCoroutine(cm.HumanAttack());
                }
            }
        }
    }
}
