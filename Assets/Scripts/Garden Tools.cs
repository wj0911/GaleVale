using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GardenTools : MonoBehaviour
{
    public int toolbarInt = 0;
    private string[] toolbarStrings = {"Move", "Plant", "Collect"};
    void OnGUI()
    {
        toolbarInt = GUI.Toolbar (new Rect (10,10,240,80), toolbarInt, toolbarStrings);
    }
}