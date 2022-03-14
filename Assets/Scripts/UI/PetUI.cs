using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class PetUI : BattleUI 
{
    override public void updateChar(Character newChar) {
        character = newChar;
    }
}
