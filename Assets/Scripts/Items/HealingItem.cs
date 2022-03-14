using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Logan Mikulski
public class HealingItem : Item {
    [SerializeField] private int hpIncrease = 50;
    public override string getItemDescription() {
        return "Health increased by " + hpIncrease;
    }
    override public string getShortDescription() {
        return "(HP+)";
    }
    // Start is called before the first frame update
    void Start() {
        itemName = "Health Potion";
    }

    public override void UseItem(CombatManager combatManager) {
        Pet currPet = combatManager.getCurrPet();

        if (currPet.getCurrHealth() + hpIncrease >= currPet.getMaxHealth()) {
            currPet.setCurrHealth(currPet.getMaxHealth());
        } else {
            currPet.setCurrHealth(currPet.getCurrHealth() + hpIncrease);
        }
    }
}
