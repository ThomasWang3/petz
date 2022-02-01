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

    public override void UseItem(CombatManager combatManager)
    {
        combatManager.currPet.currHealth = combatManager.currPet.currHealth / 2;
        combatManager.currPet.attack = combatManager.currPet.attack * 2;
    }
}
