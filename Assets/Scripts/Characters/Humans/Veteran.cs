using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veteran : Human {
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        type = "veteran";
        strengths.Add("cat");
        weaknesses.Add("snake");
    }

}
