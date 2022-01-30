using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        type = "fisherman";
        strengths.Add("snake");
        weaknesses.Add("bird");
    }
}
