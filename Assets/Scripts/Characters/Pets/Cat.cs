using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Pet
{
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        type = "cat";
        strengths.Add("bird");
        weaknesses.Add("dog");
    }

}