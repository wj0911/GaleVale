using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop Data", menuName = "Crop Data/Create New Crop Data")]
public class CropData : ScriptableObject
{
    public int rarity; //0-3, 0 = common, 1 = uncommon,...
    public int amount;
}
