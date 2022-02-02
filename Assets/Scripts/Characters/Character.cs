using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;
    public int attack;
    public string type;
    public List<string> strengths;
    public List<string> weaknesses;
    public bool isDead = false;

    public string GetCharType() {
        return type;
    }





    //protected Character() { }

    public void AttackEnemy(Character enemy) {
        if (strengths.Contains(enemy.GetCharType()) || enemy.weaknesses.Contains(type)) {
            enemy.TakeDamage(2 * attack);
        } else if (weaknesses.Contains(enemy.GetCharType()) || enemy.strengths.Contains(type)) { 
            enemy.TakeDamage(attack / 2);
        } else {
            enemy.TakeDamage(attack);
        }
    }

    public void TakeDamage(int damageTaken) {
        currHealth -= damageTaken;
        if(currHealth <= 0) {
            isDead = true;
        }
    }


}
