using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class StrengthItem : Item
{
    [SerializeField] private int attackIncrease;

    public override string getItemDescription() {
        return "Attack increased by " + attackIncrease;
    }
    override public string getShortDescription() {
        return "(ATK+)";
    }
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
