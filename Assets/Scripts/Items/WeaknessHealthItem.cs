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

    public void UseItem(CombatManager combatManager)
    {
        combatManager.currPet.health = combatManager.currPet.maxHealth;
        combatManager.currPet.attack -= strAmount;
    }
}
