using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    protected Text charName;
    protected Text hp;

    protected float maxHealth;
    protected float currHealth;

    protected Slider slider;
    protected Image fillImage;
    protected Color fullHealthColor = Color.green;
    protected Color zeroHealthColor = Color.red;

    protected CombatManager cm;
    protected Character character;

    protected virtual void OnEnable() {
        cm = FindObjectOfType<CombatManager>();
        //SetHealthUI();
    }
    public void SetHealthUI() {
        charName.text = character.getCharType();

        maxHealth = character.getMaxHealth();
        slider.maxValue = maxHealth;
        currHealth = character.getCurrHealth();
        slider.value = currHealth;


        hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        
    }

}
