using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop/Create New Crop")]
public class Crop : ScriptableObject
{
    public int amount;
    public int cost;
    public string cropName;
    public string cropType;
    public string rarity;
    public Sprite icon;
    public int qualityRequired;
}
