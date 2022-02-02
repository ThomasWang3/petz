using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected int maxHealth;
    protected int currHealth;
    protected int attack;
    protected string type;
    protected List<string> strengths;
    protected List<string> weaknesses;
    protected bool isDead = false;

    public string GetCharType() {
        return type;
    }





    //protected Character() { }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getCurrHealth()
    {
        return currHealth;
    }

    public void setCurrHealth(int newHealthVal)
    {
        currHealth = newHealthVal;
    }

    public int getAttack()
    {
        return attack;
    }

    public void setAttack(int newAttackVal)
    {
        attack = newAttackVal;
    }

    public string getCharType()
    {
        return type;
    }

    public bool getIsDead()
    {
        return isDead;
    }

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
