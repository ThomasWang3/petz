using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : Item
{
    [SerializeField] private int hpIncrease = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemName = "Healing Pill";
    }

    public override void UseItem(CombatManager combatManager)
    {
        Pet currPet = combatManager.getCurrPet();

        if (currPet.getCurrHealth() + hpIncrease >= currPet.getMaxHealth())
        {
            currPet.setCurrHealth(currPet.getMaxHealth());
        }
        else
        {
            currPet.setCurrHealth(currPet.getCurrHealth() + hpIncrease);
        }
    }
}
