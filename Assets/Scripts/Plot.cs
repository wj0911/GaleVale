using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plot", menuName = "Plot/Create New Plot")]
public class Plot : ScriptableObject
{
    public int growthState;
    public string cropType;
    public int growthSpeed;
    public int soilQuality;
    public int fineHarvest;
    public int goldenRule;
    public bool harvestable;
}
