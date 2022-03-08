using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author(s): Thomas Wang
public class HumanUI : BattleUI 
{

    protected void OnEnable() {
        character = cm.getCurrHuman();
    }

    protected override void updateChar() {
        character = cm.getCurrHuman();
    }
}
