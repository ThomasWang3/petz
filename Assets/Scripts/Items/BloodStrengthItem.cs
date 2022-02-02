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
        Pet currPet = combatManager.getCurrPet();
        currPet.setCurrHealth(currPet.getCurrHealth() / 2);
        currPet.setAttack(currPet.getAttack() * 2);
    }
}
