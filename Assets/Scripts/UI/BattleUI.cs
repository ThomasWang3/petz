using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Author(s): Thomas Wang
public class BattleUI : MonoBehaviour
{
    [SerializeField] protected Text charName;
    [SerializeField] protected Text hp;

    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currHealth;

    [SerializeField] protected Slider slider;
    [SerializeField] protected Image fillImage;
    protected Color fullHealthColor = Color.green;
    protected Color zeroHealthColor = Color.red;

    protected CombatManager cm;
    protected Character character;

    protected virtual void OnEnable() {
        cm = FindObjectOfType<CombatManager>();
    }
    
    // updates the health UI when called
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
