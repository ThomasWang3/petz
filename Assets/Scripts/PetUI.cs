using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetUI : BattleUI 
{

    protected override void OnEnable() {
        base.OnEnable();
        character = cm.currPet;

        //charName.text = character.type;

        //currHealth = character.currHealth;
        //slider.value = currHealth;
        //maxHealth = character.maxHealth;
        //slider.maxValue = maxHealth;

        //hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
        //fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
    }

    //private void SetHealthUI() {
    //    charName.text = cm.currPet.type;

    //    currHealth = cm.currPet.currHealth;
    //    slider.value = currHealth;

    //    maxHealth = cm.currPet.maxHealth;
    //    slider.maxValue = maxHealth;

    //    hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
    //    fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
    //}

    // Update is called once per frame
    void Update() {
        character = cm.currPet;
        // if the player changes pets or takes damage, rewrite the UI
        if(charName.text != character.type || currHealth != character.currHealth) {
            SetHealthUI();
        }
    }
}
