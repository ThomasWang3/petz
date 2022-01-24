using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int health;
    private int attack;
    private string type;

    public int GetHealth()
    {
        return health;
    }

    public int GetAttack()
    {
        return attack;
    }

    public string GetCharType()
    {
        return type;
    }

    public void DoDamage(int dmg)
    {
        health -= dmg;
    }
}
