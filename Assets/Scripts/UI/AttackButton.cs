using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang
public class AttackButton : MonoBehaviour
{
    [SerializeField] private CombatManager cm;
    [SerializeField] private Button buttonObject;


    // OnClick() function for the button calls Attack() from the combatmanager class
    //public void Attack() {
    //    //Debug.Log("attack button pressed");
    //    cm.attack();
    //}

    private void Update() {
        if(cm.getPetWin() || cm.getHumanWin()) {
            buttonObject.interactable = false;
        }
    }
}