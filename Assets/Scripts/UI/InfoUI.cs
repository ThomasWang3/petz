using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Thomas Wang
public class InfoUI : MonoBehaviour
{
    //[SerializeField] private CombatManager cm;
    [SerializeField] private Text infoText1;
    [SerializeField] private Text infoText2;

    public void updateText(string message) {
        if(infoText1.text.Length == 0) {
            // no actions have been logged
            infoText1.text = message;
        } else if(infoText2.text.Length == 0) {
            // only one action has been logged
            infoText2.text = message;
        } else {
            // at least two actions have been logged
            infoText1.text = infoText2.text;
            infoText2.text = message;
        }
    }

    public void newAttackText(Character attacker, Character target, int damage) {
        updateText(attacker.getName() + " attacked " + target.getName() + " for " + damage + " damage");
    }

    public void newPotionText(Character pet, Item potion) {
        string message = "Player 1 used a " + potion.getItemName() + " on " + pet.getName() + "\n";
        message += potion.getItemDescription();
        updateText(message);
    }

    public void newFaintText(Character dead) {
        updateText(dead.getName() + " fainted");
    }
}
