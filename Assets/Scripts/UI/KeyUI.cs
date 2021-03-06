using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Thomas Wang
public class KeyUI : MonoBehaviour {
    [SerializeField] private Image wKey;
    [SerializeField] private Image sKey;
    [SerializeField] private Image upKey;
    [SerializeField] private Image downKey;
    [SerializeField] private Vector3 switchKeyOffset;
    [SerializeField] private Camera camera;

    public void UpdateP1KeysPosition(Character character) {
        wKey.transform.position = camera.WorldToScreenPoint(character.transform.position) + new Vector3(switchKeyOffset.x, +switchKeyOffset.y, switchKeyOffset.z);
        sKey.transform.position = camera.WorldToScreenPoint(character.transform.position) + new Vector3(switchKeyOffset.x, -switchKeyOffset.y, switchKeyOffset.z);
    }


    public void UpdateP2KeysPosition(Character character) {
        upKey.transform.position = camera.WorldToScreenPoint(character.transform.position) + new Vector3(-switchKeyOffset.x, +switchKeyOffset.y, switchKeyOffset.z);
        downKey.transform.position = camera.WorldToScreenPoint(character.transform.position) + new Vector3(-switchKeyOffset.x, -switchKeyOffset.y, switchKeyOffset.z);
    }

    public void TurnOnP1Keys() {
        wKey.color = new Color(wKey.color.r, wKey.color.b, wKey.color.g, 1.0f);
        sKey.color = new Color(sKey.color.b, sKey.color.b, sKey.color.g, 1.0f);
    }
    public void TurnOffP1Keys() {
        wKey.color = new Color(wKey.color.r, wKey.color.b, wKey.color.g, -1.0f);
        sKey.color = new Color(sKey.color.b, sKey.color.b, sKey.color.g, -1.0f);
    }


    public void TurnOnP2Keys() {
        upKey.color = new Color(upKey.color.r, upKey.color.b, upKey.color.g, 1.0f);
        downKey.color = new Color(downKey.color.b, downKey.color.b, downKey.color.g, 1.0f);
    }
    public void TurnOffP2Keys() {
        upKey.color = new Color(upKey.color.r, upKey.color.b, upKey.color.g, -1.0f);
        downKey.color = new Color(downKey.color.b, downKey.color.b, downKey.color.g, -1.0f);
    }
}
