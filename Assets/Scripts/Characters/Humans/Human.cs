using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang, Daniel J. Garcia
public class Human : Character 
{
    public bool isInDanger()
    {
        if ((((float)currHealth/(float)maxHealth) < 0.10) && (currHealth > 0))
        {
            return true;
        }
        return false;
    }  
    
    public bool isInCaution()
    {
        if ((((float)currHealth / (float)maxHealth) < 0.25))
        {
            return true;
        }
        return false;
    }
}