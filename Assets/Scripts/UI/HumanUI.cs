using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class HumanUI : BattleUI 
{
    override public void updateChar(Character newChar) {
        character = newChar;
    }
}
