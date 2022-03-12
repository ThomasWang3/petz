using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Thomas Wang
// Create a new class to facilitate singleplayer input
// Call methods from CombatManager and have it take care of the game logic
public class AIManager : MonoBehaviour {
    [SerializeField] CombatManager cm;

    // Controls
    // P1 Pet Controls (w - previous, s - next)
    [SerializeField] private KeyCode p1PrevKey;
    [SerializeField] private KeyCode p1NextKey;

    // P1 Item Controls (a - previous,  - next, e - use item)
    [SerializeField] private KeyCode prevItemKey;
    [SerializeField] private KeyCode nextItemKey;
    [SerializeField] private KeyCode useItemKey;

    // P1 Attack Controls (space - attack)
    [SerializeField] private KeyCode p1AttackKey;


    // Update is called once per frame
    void Update() {
        if (!cm.getIsPaused() && !cm.getisAttacking()) {
            // The scene is singleplayer
            if (cm.getP1Turn()) {
                if (Input.GetKeyDown(p1PrevKey)) {
                    cm.PreviousPet();
                } else if (Input.GetKeyDown(p1NextKey)) {
                    cm.NextPet();
                } else if (Input.GetKeyDown(prevItemKey) && cm.getCurrPet() != null) {
                    cm.PreviousItem();
                } else if (Input.GetKeyDown(nextItemKey) && cm.getCurrPet() != null) {
                    cm.NextItem();
                } else if (Input.GetKeyDown(useItemKey) && cm.getCurrPet() != null) {
                    //pass the item the combat manager so the item's actions can be carried out
                    cm.UseItem();
                    // since a player can use an item and attack, we don't call humanAttack() afterwards
                    //humanAttack();
                } else if (Input.GetKeyDown(p1AttackKey)) {
                    //Debug.Log("space button pressed");
                    StartCoroutine(cm.PetAttack());
                }
            } else {
                if (!cm.getPetWin() && !cm.getHumanWin()) {
                    cm.humanSwitchStrategy();
                    cm.HumanSafety();
                    StartCoroutine(cm.AIAttack());
                }
            }
        }
    }
}
