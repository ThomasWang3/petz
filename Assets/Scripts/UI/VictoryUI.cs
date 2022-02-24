using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Author(s): Thomas Wang
public class VictoryUI : MonoBehaviour
{
    [SerializeField] private CombatManager cm;
    [SerializeField] private MultiplayerCombatManager mcm;
    [SerializeField] private Text victoryText;
    // Start is called before the first frame update
    void Start()
    {
        if (cm != null){
            cm = FindObjectOfType<CombatManager>();
        } else 
        if (mcm != null){
            mcm = FindObjectOfType<MultiplayerCombatManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cm != null){
            if (cm.getPetWin()) {
                victoryText.text = "Pets Win!";
            } else if (cm.getHumanWin()) {
                victoryText.text = "Humans Win!";
            }
        } else 
        if (mcm != null){
            if (mcm.getPetWin()) {
                victoryText.text = "Pets Win!";
            } else if (mcm.getHumanWin()) {
                victoryText.text = "Humans Win!";
            }
        }
    }
}
