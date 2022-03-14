using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Author(s): Thomas Wang, Logan Mikulski
public class VictoryUI : MonoBehaviour
{
    [SerializeField] private Text victoryText;
    // Start is called before the first frame update

    public void PetVictory() {
        victoryText.text = "Pets Win!";
    }

    public void HumanVictory() {
        victoryText.text = "Humans Win!";
    }

}
