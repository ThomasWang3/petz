using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class PunkKid : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        name = "punkkid";
        type = "snake";
        strengths.Add("dog");
        weaknesses.Add("fish");
    }
}
