using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VictoryUI : MonoBehaviour
{
    public CombatManager cm;
    public Text victoryText;
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CombatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cm.petWin) {
            victoryText.text = "Pets Win!";
        } else if (cm.humanWin) {
            victoryText.text = "Humans Win!";
        }
    }
}
