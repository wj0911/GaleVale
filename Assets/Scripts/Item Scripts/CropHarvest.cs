using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropHarvest : MonoBehaviour
{
    public Crop crop;
    public GameObject harvestTool;

    void Pickup() {
        crop.amount += 1;
        InventoryCropManager.Instance.UpdateInventory();
    }

    private void OnMouseDown() {
        Pickup();
    }
}
