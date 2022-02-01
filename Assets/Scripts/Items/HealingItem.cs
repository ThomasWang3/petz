using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : Item
{
    public int hpIncrease = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Healing Pill";
    }

    public void UseItem(CombatManager combatManager)
    {
        if (combatManager.currPet.health + hpIncrease >= combatManager.currPet.maxHealth)
        {
            combatManager.currPet.health = combatManager.currPet.maxHealth;
        }
        else
        {
            combatManager.currPet.health += hpIncrease;
        }
    }
}
