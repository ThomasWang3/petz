using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthItem : Item
{
    public int strIncrease = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Strength Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        combatManager.currPet.attack += strIncrease;
    }
}
