using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class Fisherman : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        name = "fisherman";
        type = "fish";
        strengths.Add("snake");
        weaknesses.Add("bird");
    }
}
