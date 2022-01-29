using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;
    public int attack;
    public string type;
    public List<string> strengths;
    public List<string> weaknesses;

    public string GetCharType() {
        return type;
    }

    protected Character() { }

    public void AttackEnemy(Character human) {
        if (strengths.Contains(human.GetCharType())) {
            human.TakeDamage(2 * attack);
        } else if (weaknesses.Contains(human.GetCharType())) {
            human.TakeDamage(attack / 2);
        } else {
            human.TakeDamage(attack);
        }
    }

    public void TakeDamage(int damageTaken) {
        health -= damageTaken;
    }


}
