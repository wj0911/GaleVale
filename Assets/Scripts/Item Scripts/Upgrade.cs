using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Create New Upgrade")]
public class Upgrade : ScriptableObject
{
    public int level;
    public int maxLevel;
    public int cost;
    public void increment() {
        if ((this.name == "Growth Speed") || (this.name == "Soil Quality") || (this.name == "Fine Harvest")) {
            cost += 100;
        } else {
            cost += 500;
        }
    }
}