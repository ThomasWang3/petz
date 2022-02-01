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

    public override void UseItem(CombatManager combatManager)
    {
        if (combatManager.currPet.currHealth + hpIncrease >= combatManager.currPet.maxHealth)
        {
            combatManager.currPet.currHealth = combatManager.currPet.maxHealth;
        }
        else
        {
            combatManager.currPet.currHealth += hpIncrease;
        }
    }
}
