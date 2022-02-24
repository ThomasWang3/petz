using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class RichMan : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        name = "richman";
        type = "bird";
        strengths.Add("fish");
        weaknesses.Add("cat");
    }
}
