using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class Dog : Pet{
    // Start is called before the first frame update
    public void Start(){
        currHealth = maxHealth;
        name = "dog";
        type = "dog";
        strengths.Add("cat");
        weaknesses.Add("snake");
    }

}
