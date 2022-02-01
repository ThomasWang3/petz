using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int numHeld;
    public string itemName;

    public abstract void UseItem(CombatManager combatManager);
}
