using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodStrengthItem : Item
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Blood for Strength Pill";
    }

    public void UseItem(CombatManager combatManager)
    {
        combatManager.currPet.health = combatManager.currPet.health / 2;
        combatManager.currPet.attack = combatManager.currPet.attack * 2;
    }
}
