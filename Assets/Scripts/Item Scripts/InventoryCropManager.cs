using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCropManager : MonoBehaviour
{
    public static InventoryCropManager Instance;
    public List<Crop> Crops = new List<Crop>();

    public Transform CropContent;
    public GameObject InventoryCrop;
    public ToggleGroup inventory;

    private void Awake()
    {
        Instance = this;
        UpdateInventory();
    }

    public void Add(Crop crop) {
        if (Crops.Contains(crop)) {
            for (int i = 0; i < Crops.Count; i++) {
                if (Crops[i] == crop) {
                    Crops[i].amount += 1;
                    break;
                }
            }
        } else {
            Crops.Add(crop);
        }
    }

    public void UpdateInventory() {
        List<Crop> cropsInOrder = CropList.Instance.GetCropList("upName");
        Crops = new List<Crop>();
        foreach (Crop crop in cropsInOrder) {
            if (crop.amount > 0) {
                Crops.Add(crop);
            }
        }
        ListItems();
    }

    public void Remove(Crop crop) {
        Crops.Remove(crop);
    }

    public void ListItems() {
        // Removes inventory items before re-adding them
        foreach (Transform item in CropContent) {
            Destroy(item.gameObject);
        }

        foreach (var crop in Crops) {
            GameObject obj = Instantiate(InventoryCrop, CropContent);
            var cropName = obj.transform.Find("CropText").GetComponent<TextMeshProUGUI>();
            var cropIcon = obj.transform.Find("CropIcon").GetComponent<Image>();

            cropName.text = crop.cropName + " x" + crop.amount.ToString();
            cropIcon.sprite = crop.icon;
            obj.GetComponent<Hoverable>().tooltipText = "Price per-unit: " + crop.cost.ToString() + "g";
            obj.GetComponent<Toggle>().group = inventory;
            obj.GetComponent<CropController>().crop = crop;
        }
    }
}
