using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesUpdater : MonoBehaviour
{
    public TMP_Text upgradeTextDisplay;
    public Upgrade upgrade;

    public void UpdateUpgradeDisplay() {
        upgradeTextDisplay.text = upgrade.name + " " + romanify(upgrade.level);
    }

    public string romanify(int num) {
        if (num == 1) {
            return "I";
        } else if (num == 2) {
            return "II";
        } else if (num == 3) {
            return "III";
        } else if (num == 4) {
            return "IV";
        } else if (num == 5) {
            return "V";
        } else if (num == 6) {
            return "VI";
        } else if (num == 7) {
            return "VII";
        } else if (num == 8) {
            return "VIII";
        } else if (num == 9) {
            return "IX";
        } else {
            return "X";
        }
    }

    void Start() {
        UpdateUpgradeDisplay();
    }
}
