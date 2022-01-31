using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public Text charName;
    public Text hp;

    public float maxHealth;
    public float currHealth;

    public Slider slider;
    public Image fillImage;
    protected Color fullHealthColor = Color.green;
    protected Color zeroHealthColor = Color.red;

    protected CombatManager cm;
    protected Character character;

    protected virtual void OnEnable() {
        cm = FindObjectOfType<CombatManager>();
        //SetHealthUI();
    }
    public void SetHealthUI() {
        charName.text = character.type;

        maxHealth = character.maxHealth;
        slider.maxValue = maxHealth;
        currHealth = character.currHealth;
        slider.value = currHealth;


        hp.text = currHealth.ToString() + " / " + maxHealth.ToString();
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currHealth / maxHealth);
        
    }

}
