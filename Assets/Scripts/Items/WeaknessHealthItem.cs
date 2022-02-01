using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaknessHealthItem : Item
{
    public int strAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Weakness for Health Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        combatManager.currPet.currHealth = combatManager.currPet.maxHealth;
        combatManager.currPet.attack -= strAmount;
    }
}
