using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class Cat : Pet
{
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        name = "cat";
        type = "cat";
        strengths.Add("bird");
        weaknesses.Add("dog");
    }

}
