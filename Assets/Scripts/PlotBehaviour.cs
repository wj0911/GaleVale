using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotBehaviour : MonoBehaviour
{
    public GameObject toolbar, locked, blocked, plotBuyMenu, toolbarDisplay;
    public int growthState;
    public Sprite empty, seeded, halfgrown, grown;
    public int growthPity;
    public Crop crop;
    public Upgrade growthSpeed, soilQuality, fineHarvest, committed, goldenRule;
    public bool isLocked;

    IEnumerator blockPlot() {
        blocked.SetActive(true);
        yield return new WaitForSeconds(1);
        blocked.SetActive(false);
    }

    public void Grow() {
        Sprite[] plotSprites = {halfgrown, grown};
        if (growthState == 1 || growthState == 2) {
            growthState += 1;
            GetComponent<Image>().sprite = plotSprites[growthState-2];
        } 
    }

    public void Harvest() {
        if (growthState == 3) {
            growthState = 0;
            GetComponent<Image>().sprite = empty;
            crop.amount += 1;
            if (Random.Range(1,100) <= fineHarvest.level) {
                crop.amount += 1;
            }
            InventoryCropManager.Instance.UpdateInventory();
        }
    }

    public void Plant() {
        if (growthState == 0) {
            string selectedCrop = GetValueFromDropdown.Instance.GetDropdownValue();
            List<Crop> cropList = CropList.Instance.GetCrop(selectedCrop);
            int cropRarity = Random.Range(0, 100);
            if (cropRarity > 94) {
                crop = cropList[3];
            } else if (cropRarity > 79) {
                crop = cropList[2];
            } else if (cropRarity > 59) {
                crop = cropList[1];
            } else {
                crop = cropList[0];
            }
            if (crop.qualityRequired <= soilQuality.level) {
                growthState = 1;
                GetComponent<Image>().sprite = seeded;
            } else {
                StartCoroutine(blockPlot());
            }
        }
    }

    void Update () {
        if (Time.frameCount % 10 == 0) {
            if (Random.Range (0, 10000) <= (1 + growthSpeed.level/10)*growthPity) {
                Grow();
                growthPity = 0;
            } else {
                growthPity += 1;
            }
        }
    }

    void OnMouseDown() {
        if (isLocked) {
            plotBuyMenu.SetActive(true);
            toolbarDisplay.SetActive(false);
            plotBuyMenu.GetComponent<PlotBuyManager>().selectedPlot = gameObject;
            plotBuyMenu.GetComponent<PlotBuyManager>().updateDisplay();
        } else if (toolbar.GetComponent<ToggleGroup>().GetFirstActiveToggle().name == "Harvest Toggle") {
            Harvest();
        } else {
            Plant();
        }
    }
}
