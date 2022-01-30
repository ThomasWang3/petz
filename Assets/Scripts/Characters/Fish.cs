using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Pet{
    // Start is called before the first frame update
    public void Start(){
        currHealth = maxHealth;
        type = "fish";
        strengths.Add("snake");
        weaknesses.Add("bird");
    }

    
}
