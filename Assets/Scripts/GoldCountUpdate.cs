using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCountUpdate : MonoBehaviour
{
    public TMP_Text goldCountDisplay;
    public storedValue gold;

    public void UpdateGoldCount() {
        goldCountDisplay.text = "Gold: " + gold.value.ToString() + "g";
    }

    void Start()
    {
        UpdateGoldCount();
    }
}
