using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanUI : BattleUI 
{

    protected override void OnEnable() {
        base.OnEnable();
        character = cm.getCurrHuman();
    }

    // Update is called once per frame
    void Update() {
        character = cm.getCurrHuman();
        // if the player changes pets or takes damage, rewrite the UI
        if (character != null) {
            if (charName.text != character.getCharType()) {
                character.gameObject.SetActive(false);
                character = cm.getCurrHuman();
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
