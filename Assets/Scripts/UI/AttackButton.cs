using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang
public class AttackButton : MonoBehaviour
{
    [SerializeField] private CombatManager cm;
    [SerializeField] private Button buttonObject;


    private void Update() {
        if(cm.getPetWin() || cm.getHumanWin()) {
            buttonObject.interactable = false;
        }
    }
}