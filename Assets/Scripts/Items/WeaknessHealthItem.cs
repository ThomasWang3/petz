using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class WeaknessHealthItem : Item
{
    [SerializeField] private int attackDecrease = 5;
    public override string getItemDescription() {
        return "Health fully restored and attack decreased by " + attackDecrease;
    }

    override public string getShortDescription() {
        return "(HPMax / ATK-)";
    }

    // Start is called before the first frame update
    void Start()
    {
        itemName = "Berserk Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        Pet currPet = combatManager.getCurrPet();
        currPet.setCurrHealth(currPet.getMaxHealth());
        currPet.setAttack(currPet.getAttack() - attackDecrease);
    }
}
