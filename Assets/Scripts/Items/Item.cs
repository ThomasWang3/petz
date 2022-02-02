using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected int numHeld;
    [SerializeField] protected string itemName;


    public int getNumItemHeld()
    {
        return numHeld;
    }

    public string getItemName()
    {
        return itemName;
    }

    public abstract void UseItem(CombatManager combatManager);
}
