using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Pet{
    // Start is called before the first frame update
    public void Start() {
        currHealth = maxHealth;
        type = "bird";
        strengths.Add("fish");
        weaknesses.Add("cat");
    }

}
