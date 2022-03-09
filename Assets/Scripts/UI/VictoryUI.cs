using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Author(s): Thomas Wang
public class VictoryUI : MonoBehaviour
{
    [SerializeField] private CombatManager cm;
    [SerializeField] private Text victoryText;
    [SerializeField] private LevelManager lm;
    // Start is called before the first frame update
    
    public void Victory() {
        if (cm.getPetWin()) {
            victoryText.text = "Pets Win!";
            StartCoroutine(ReturnToOverworld());
        } else if (cm.getHumanWin()) {
            victoryText.text = "Humans Win!";
            StartCoroutine(ReturnToOverworld());
        }
    }

    private IEnumerator ReturnToOverworld() {
        Debug.Log("Victory! Loading Overworld");
        yield return new WaitForSeconds(1.0f);
        lm.LoadLevelWithIndex(1);
    }

}
