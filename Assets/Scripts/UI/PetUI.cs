using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class PetUI : BattleUI 
{

    protected override void OnEnable() {
        base.OnEnable();
        character = cm.getCurrPet();
    }


    // Update is called once per frame
    void Update() {
        character = cm.getCurrPet();
        // if the player changes pets or takes damage, rewrite the UI
        if (character != null) {
            if (charName.text != character.getName()) {
                character.gameObject.SetActive(false);
                character = cm.getCurrPet();
                character.gameObject.SetActive(true);
                SetHealthUI();
            }
            if (currHealth != character.getCurrHealth()) {
                SetHealthUI();
            }
        } else {
            // used to check if the last pet is null, and then appropriately change the HP text to 0/maxHealth;
            currHealth = 0;
            slider.value = currHealth;
            hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        }
    }
}
