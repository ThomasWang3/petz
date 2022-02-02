using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class OldLady : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        type = "OldLady";
        strengths.Add("bird");
        weaknesses.Add("dog");
    }
}
