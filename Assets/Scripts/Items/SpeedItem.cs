using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class SpeedItem : Item {
    public override string getItemDescription() {
        return "Speed increased (get to attack twice)";
    }
    override public string getShortDescription() {
        return "(Skip Enemy Turn)";
    }
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Speed Potion";
    }

    public override void UseItem(CombatManager combatManager)
    {
        combatManager.setSkipTurn(true);
    }
}
