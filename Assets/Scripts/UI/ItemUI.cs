using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Thomas Wang
public class ItemUI : MonoBehaviour
{
    [SerializeField] protected Text potionName;
    [SerializeField] protected Text potionDesc;

    public void SetPotionUI(Item potion) {
        potionName.text = potion.getItemName();
        potionDesc.text = potion.getShortDescription();
    }

    public void EmptyPotionUI() {
        potionName.text = "N/A";
        potionDesc.text = "N/A";
    }
}
