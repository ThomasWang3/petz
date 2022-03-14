using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Author(s): Thomas Wang, Logan Mikulski
public class VictoryUI : MonoBehaviour
{
    [SerializeField] private Text victoryText;
    // Start is called before the first frame update

    public void Victory(bool petWin, bool humanWin)
    {
        if (petWin)
        {
            victoryText.text = "Pets Win!";
        }
        else if (humanWin)
        {
            victoryText.text = "Humans Win!";
        }
    }
}
