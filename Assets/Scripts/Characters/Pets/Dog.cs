using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Pet{
    // Start is called before the first frame update
    public void Start(){
        currHealth = maxHealth;
        type = "dog";
        strengths.Add("cat");
        weaknesses.Add("snake");
    }

}
