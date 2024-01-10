using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommissionManager : MonoBehaviour
{
    public Upgrade committed;
    public TMP_Text sellMenuButton, commissionText, goldCount, sellMenuText;
    public GameObject sellMenu, sellInput, inventory, commissionObject, commissionButton;
    public string crop;
    public int quantityDemanded;
    public storedValue gold;

    public void openSellMenu() {
        sellMenu.SetActive(true);
        commissionButton.SetActive(true);
        sellMenuText.text = "COMMISSION! \nEnter the amount to sell:";
    }

    public void closeSellMenu() {
        commissionButton.SetActive(false);
        sellMenu.SetActive(false);
    }

    public void sellMenuRequested() {
        if (inventory.GetComponent<ToggleGroup>().GetFirstActiveToggle() == null) {
            sellMenuButton.text = "SELECT A CROP";
        } else if (! (inventory.GetComponent<ToggleGroup>().GetFirstActiveToggle().GetComponent<CropController>().crop.cropType == crop)) {
            sellMenuButton.text = "WRONG CROP";
        } else {
            sellMenuButton.text = "SELL";
            openSellMenu();
        }
    }

    public void rerollCrop() {
        int newCrop = Random.Range(0,5);
        if (newCrop == 0) {
            crop = "Potato";
        } else if (newCrop == 1) {
            crop = "Yam";
        } else if (newCrop == 2) {
            crop = "Carrot";
        } else if (newCrop == 3) {
            crop = "Beet";
        } else {
            crop = "Onion";
        }
        quantityDemanded = Random.Range(20,50);
    }

    public void commissionItems() {
        int sellAmount;
        int.TryParse(sellInput.GetComponent<TMP_InputField>().text, out sellAmount);
        Crop selectedCrop = inventory.GetComponent<ToggleGroup>().GetFirstActiveToggle().GetComponent<CropController>().crop;
        if (sellAmount > quantityDemanded) {
            sellAmount = quantityDemanded;
        }
        if (! (selectedCrop.cropType == crop)) {
            sellMenuText.text = "Wrong type of crop!";
        } else if (sellAmount < 0) {
            sellMenuText.text = "You can't sell a negative amount!";
        } else if (sellAmount >= selectedCrop.amount) {
            gold.value += (int)(selectedCrop.amount * selectedCrop.cost*1.5);
            selectedCrop.amount = 0;
            InventoryCropManager.Instance.Remove(selectedCrop);
            InventoryCropManager.Instance.ListItems();
            quantityDemanded -= selectedCrop.amount;
            closeSellMenu();
        } else {
            gold.value += (int)(sellAmount * selectedCrop.cost*1.5);
            selectedCrop.amount -= sellAmount;
            quantityDemanded -= sellAmount;
            InventoryCropManager.Instance.ListItems();
            closeSellMenu();
        }
        goldCount.text = "Gold: " + gold.value.ToString() + "g";
        if (quantityDemanded == 0) {
            rerollCrop();
        }
        updateCommissionDisplay();
    }

    public void updateCommissionDisplay() {
        if ((commissionObject.name == "Commission 1")||((commissionObject.name == "Commission 2") && (committed.level >= 2))||((commissionObject.name == "Commission 3") && (committed.level == 3))) {
            commissionText.text = commissionObject.name + ":\n" + crop + " x" + quantityDemanded.ToString();
        } else {
            commissionText.text = commissionObject.name + ":\nLocked!";
        }
    }

    void Start() {
        rerollCrop();
        updateCommissionDisplay();
    }
}
