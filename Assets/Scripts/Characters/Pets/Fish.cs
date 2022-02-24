using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class Fish : Pet{
    // Start is called before the first frame update
    public void Start(){
        currHealth = maxHealth;
        name = "fish";
        type = "fish";
        strengths.Add("snake");
        weaknesses.Add("bird");
    }

    
}
