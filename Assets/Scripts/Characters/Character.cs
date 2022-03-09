using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang, Logan Mikulski
public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currHealth;
    [SerializeField] protected int attack;
    [SerializeField] protected new string name;
    [SerializeField] protected string type;
    [SerializeField] protected List<string> strengths;
    [SerializeField] protected List<string> weaknesses;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected int matchState = 0;

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

    public string getName() {
        return name;
    }
    public string getCharType() {
        return type;
    }

    public bool getIsDead()
    {
        return isDead;
    }

    public int getMatchState()
    {
        return matchState;
    }

    public int AttackEnemy(Character enemy) {
        if (strengths.Contains(enemy.getCharType()) || enemy.weaknesses.Contains(type)) {
            matchState = 2;
            return enemy.TakeDamage(2 * attack);
        } else if (weaknesses.Contains(enemy.getCharType()) || enemy.strengths.Contains(type)) {
            matchState = 1;
            return enemy.TakeDamage(attack / 2);
        } else {
            matchState = 0;
            return enemy.TakeDamage(attack);
        }
    }

    public int TakeDamage(int damageTaken) {
        currHealth -= damageTaken;
        if(currHealth <= 0) {
            isDead = true;
        }
        return damageTaken;
    }


}
