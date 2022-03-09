using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class BerserkItem : Item
{

    public override string getItemDescription() {
        return "Health halved and Attack doubled";
    }
    override public string getShortDescription() {
        return "(ATK+ / HP-)";
    }
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Berserk Potion";
    }

    public override void UseItem(CombatManager combatManager)
    {
        Pet currPet = combatManager.getCurrPet();
        currPet.setCurrHealth(currPet.getCurrHealth() / 2);
        currPet.setAttack(currPet.getAttack() * 2);
    }
}
