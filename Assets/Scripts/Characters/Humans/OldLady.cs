using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        type = "OldLady";
        strengths.Add("bird");
        weaknesses.Add("dog");
    }
}