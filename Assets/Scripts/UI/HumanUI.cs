using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class HumanUI : BattleUI 
{

    protected void OnEnable() {
        if (cm != null){
            character = cm.getCurrHuman();
        } else 
        if (mcm != null){
            character = mcm.getCurrHuman();
        }
    }

    // Update is called once per frame
    void Update() {
        if (cm != null){
            character = cm.getCurrHuman();
        } else 
        if (mcm != null){
            character = mcm.getCurrHuman();
        }
        // if the player changes pets or takes damage, rewrite the UI
        if (character != null) {
            if (charName.text != character.getName()) {
                character.gameObject.SetActive(false);
                if (cm != null){
                    character = cm.getCurrHuman();
                } else 
                if (mcm != null){
                    character = mcm.getCurrHuman();
                }
                character.gameObject.SetActive(true);
                SetHealthUI();
            }
            if (currHealth != character.getCurrHealth()) {
                SetHealthUI();
            }
        } else {
            // used to check if the last human is null, and then appropriately change the HP text to 0/maxHealth;
            currHealth = 0;
            slider.value = currHealth;
            hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        }
    }
}
