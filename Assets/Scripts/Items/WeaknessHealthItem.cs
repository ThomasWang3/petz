using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class WeaknessHealthItem : Item
{
    [SerializeField] private int attackAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Weakness for Health Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        Pet currPet = combatManager.getCurrPet();
        currPet.setCurrHealth(currPet.getMaxHealth());
        currPet.setAttack(currPet.getAttack() - attackAmount);
    }
}
