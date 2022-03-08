using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Author(s): Thomas Wang
public class BattleUI : MonoBehaviour
{
    [SerializeField] protected Text charName;
    [SerializeField] protected Text charType;
    [SerializeField] protected Text hp;

    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currHealth;

    [SerializeField] protected Slider slider;
    [SerializeField] protected Image fillImage;
    protected Color fullHealthColor = Color.green;
    protected Color zeroHealthColor = Color.red;

    [SerializeField] protected CombatManager cm;
    //[SerializeField] protected MultiplayerCombatManager mcm;
    protected Character character;

    protected virtual void updateChar() { }



    public void SetHealthUI() {
        charName.text = character.getName();
        charType.text = character.getCharType();

        maxHealth = character.getMaxHealth();
        slider.maxValue = maxHealth;
        currHealth = character.getCurrHealth();
        slider.value = currHealth;


        hp.text = currHealth.ToString() + " / " + maxHealth.ToString() + " hp";
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        
    }

    protected void Update() {
        updateChar();
        if (character != null) {
            if (charName.text != character.getName()) {
                character.gameObject.SetActive(false);
                updateChar();
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
            hp.text = currHealth.ToString() + " / " + maxHealth.ToString() + " hp";
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        }
    }

}
