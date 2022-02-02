using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private CombatManager cm;

    // Start is called before the first frame update
    void Start() {
        cm = FindObjectOfType<CombatManager>();
    }

    public void attack() {
        Debug.Log("attack button pressed");
        cm.attack();
    }
}
