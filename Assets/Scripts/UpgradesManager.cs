using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public storedValue gold;
    public Upgrade growthSpeed, soilQuality, fineHarvest, committed, goldenRule;

    public void buyUpgrade(Upgrade upgrade){
        if ((upgrade.level < upgrade.maxLevel) & (gold.value >= upgrade.cost)) {
            upgrade.level += 1;
            gold.value -= upgrade.cost;
            upgrade.increment();
        }
    }
}