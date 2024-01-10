using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barn : MonoBehaviour
{   public GameObject inventoryMenu;

    void Update() {
        //growthSpeedText.text = "Growth Speed " + growthSpeed;
        //if(Input.GetKeyDown(KeyCode.Space)){
            //growthSpeed++;
        //}
    }

    public void moveInventoryForBarn() {
        inventoryMenu.transform.localPosition = new Vector3(420, -20, -1);
    }

    public void moveInventory() {
        inventoryMenu.transform.localPosition = new Vector3(0, 0, -1);
    }
}
