using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class HumanUI : BattleUI 
{

    protected void OnEnable() {
        character = cm.getCurrHuman();
    }

    override protected void updateChar() {
        character = cm.getCurrHuman();
    }
}
