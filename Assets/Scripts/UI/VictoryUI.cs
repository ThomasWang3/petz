using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Author(s): Thomas Wang
public class VictoryUI : MonoBehaviour
{
    [SerializeField] private CombatManager cm;
    [SerializeField] private Text victoryText;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (cm.getPetWin()) {
            victoryText.text = "Pets Win!";
        } else if (cm.getHumanWin()) {
            victoryText.text = "Humans Win!";
        }
    }
}
