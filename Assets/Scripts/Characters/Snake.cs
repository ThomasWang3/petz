using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Pet{
    // Start is called before the first frame update
    public void Start(){
        currHealth = maxHealth;
        type = "snake";
        strengths.Add("dog");
        weaknesses.Add("fish");
    }
}
