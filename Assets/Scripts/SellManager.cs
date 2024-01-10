using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellManager : MonoBehaviour
{
    public GameObject sellMenu, inventory, sellInput, sellButton;
    public TMP_Text sellMenuButton, sellMenuText, goldCount;
    public storedValue gold;

    public void openSellMenu() {
        sellMenu.SetActive(true);
        sellButton.SetActive(true);
        sellMenuText.text = "Enter the amount to sell:";
    }

    public void closeSellMenu() {
        sellMenu.SetActive(false);
        sellButton.SetActive(false);
    }

    public void sellMenuRequested() {
        if (inventory.GetComponent<ToggleGroup>().GetFirstActiveToggle() == null) {
            sellMenuButton.text = "SELECT A CROP";
        } else {
            sellMenuButton.text = "SELL";
            openSellMenu();
            Debug.Log(inventory.GetComponent<ToggleGroup>().GetFirstActiveToggle().GetComponent<CropController>().crop);
        }
    }

    public void sellItems() {
        int sellAmount;
        int.TryParse(sellInput.GetComponent<TMP_InputField>().text, out sellAmount);
        Crop selectedCrop = inventory.GetComponent<ToggleGroup>().GetFirstActiveToggle().GetComponent<CropController>().crop;
        if (sellAmount < 0) {
            sellMenuText.text = "You can't sell a negative amount!";
        } else if (sellAmount >= selectedCrop.amount) {
            gold.value += selectedCrop.amount * selectedCrop.cost;
            selectedCrop.amount = 0;
            InventoryCropManager.Instance.Remove(selectedCrop);
            InventoryCropManager.Instance.ListItems();
            closeSellMenu();
        } else {
            gold.value += sellAmount * selectedCrop.cost;
            selectedCrop.amount -= sellAmount;
            InventoryCropManager.Instance.ListItems();
            closeSellMenu();
        }
        goldCount.text = "Gold: " + gold.value.ToString() + "g";
    }
}
