using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class SpeedItem : Item
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Speed Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        //combatManager.SkipEnemyTurn();
    }
}
