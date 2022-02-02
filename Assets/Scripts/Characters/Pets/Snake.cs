using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class Snake : Pet{
    // Start is called before the first frame update
    public void Start(){
        currHealth = maxHealth;
        type = "snake";
        strengths.Add("dog");
        weaknesses.Add("fish");
    }
}
