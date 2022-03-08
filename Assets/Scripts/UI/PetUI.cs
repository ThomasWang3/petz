using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class PetUI : BattleUI 
{

    protected void OnEnable() {
        character = cm.getCurrPet();
    }

    override protected void updateChar() {
        character = cm.getCurrPet();
    }
}
