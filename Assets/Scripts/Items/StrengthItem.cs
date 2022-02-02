using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthItem : Item
{
    [SerializeField] private int attackIncrease = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Strength Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        Pet currPet = combatManager.getCurrPet();
        currPet.setAttack(currPet.getAttack() + attackIncrease);
    }
}
