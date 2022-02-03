using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang
public class AttackButton : MonoBehaviour
{
    [SerializeField] private CombatManager cm;
    [SerializeField] private Button buttonObject;

    // Start is called before the first frame update
    void Start() {
        cm = FindObjectOfType<CombatManager>();
        buttonObject = gameObject.GetComponent<Button>();
    }

    // OnClick() function for the button calls attack() from the combatmanager class
    public void attack() {
        //Debug.Log("attack button pressed");
        cm.attack();
    }

    private void Update() {
        if(cm.getPetWin() || cm.getHumanWin()) {
            buttonObject.interactable = false;
        }
    }
}
