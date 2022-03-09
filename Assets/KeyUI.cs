using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private Image wKey;
    [SerializeField] private Image sKey;
    [SerializeField] private Vector3 switchKeyOffset;
    [SerializeField] private Camera camera;

    public void UpdateSwitchKeysPosition(Character character) {
        wKey.transform.position = camera.WorldToScreenPoint(character.transform.position) + new Vector3(switchKeyOffset.x, +switchKeyOffset.y, switchKeyOffset.z);
        sKey.transform.position = camera.WorldToScreenPoint(character.transform.position) + new Vector3(switchKeyOffset.x, -switchKeyOffset.y, switchKeyOffset.z);
    }

    //public void DimWKey() {
    //    wKey.color += new Color(0, 0, 0, -0.6f);
    //}
    //public void LightWKey() {
    //    wKey.color += new Color(0, 0, 0, 0.6f);
    //}
    //public void DimSKey() {
    //    sKey.color += new Color(0, 0, 0, -0.6f);
    //}
    //public void LightSKey() {
    //    sKey.color += new Color(0, 0, 0, 0.6f);
    //}
    public void TurnOnSwitchKeys() {
        wKey.color = new Color(wKey.color.r, wKey.color.b, wKey.color.g, 1.0f);
        sKey.color = new Color(sKey.color.b, sKey.color.b, sKey.color.g, 1.0f);
    }
    public void TurnOffSwitchKeys() {
        wKey.color = new Color(wKey.color.r, wKey.color.b, wKey.color.g, -1.0f);
        sKey.color = new Color(sKey.color.b, sKey.color.b, sKey.color.g, -1.0f);
    }
}
