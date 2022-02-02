using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanUI : BattleUI 
{

    protected override void OnEnable() {
        base.OnEnable();
        character = cm.getCurrHuman();

        //charName.text = character.type;

        //maxHealth = character.maxHealth;
        //slider.maxValue = maxHealth;
        //currHealth = character.currHealth;
        //slider.value = currHealth;

        //hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
        //fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
    }

    //private void SetHealthUI() {
    //    charName.text = cm.currHuman.type;

    //    currHealth = cm.currHuman.currHealth;
    //    slider.value = currHealth;

    //    maxHealth = cm.currHuman.maxHealth;
    //    slider.maxValue = maxHealth;

    //    hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
    //    fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
    //}

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
            currHealth = 0;
            slider.value = currHealth;
            hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        }
    }
}
