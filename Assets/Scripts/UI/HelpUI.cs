using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang
public class HelpUI : MonoBehaviour {
    [SerializeField] private GameObject helpUI;
    [SerializeField] private bool help = false;
    [SerializeField] private List<Text> texts;
    [SerializeField] private int textIndex;

    public bool IsHelp() {
        return help;
    }

    // Update is called once per frame
    public void Help() {
        if (!help) {
            helpUI.SetActive(true);
            help = true;
        } else {
            helpUI.SetActive(false);
            help = false;
        }
    }

    public void NextText() {
        if (textIndex < texts.Count - 1) {
            texts[textIndex].gameObject.SetActive(false);
            textIndex++;
            texts[textIndex].gameObject.SetActive(true);
        }
    }

    public void PrevText() {
        if (textIndex > 0) {
            texts[textIndex].gameObject.SetActive(false);
            textIndex--;
            texts[textIndex].gameObject.SetActive(true);
        }
    }
}