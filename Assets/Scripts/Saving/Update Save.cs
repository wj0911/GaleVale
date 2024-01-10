using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateSave : MonoBehaviour
{
    public class SaveFile
    {
        public List<bool> plots;
        public int gold;
        public List<int> cropInventoryAmount;
        public List<string> cropInventoryName;
        public List<int> cropInventoryRarity;
        public string commission1Crop;
        public int commission1QuantityDemanded;
        public string commission2Crop;
        public int commission2QuantityDemanded;
        public string commission3Crop;
        public int commission3QuantityDemanded;
        public int plotsBought;
        public List<int> upgradesLevel;
        public List<int> upgradesCost;

        public SaveFile(List<bool> ps, int g, List<int> cia, List<string> cin, List<int> cir, string c1c, int c1qd, string c2c, int c2qd, string c3c, int c3qd, int pb, List<int> ul, List<int> uc)
        {
            plots = ps;
            gold = g;
            cropInventoryAmount = cia;
            cropInventoryName = cin;
            cropInventoryRarity = cir;
            commission1Crop = c1c;
            commission1QuantityDemanded = c1qd;
            commission2Crop = c2c;
            commission2QuantityDemanded = c2qd;
            commission3Crop = c3c;
            commission3QuantityDemanded = c3qd;
            plotsBought = pb;
            upgradesLevel = ul;
            upgradesCost = uc;
        }

        public SaveFile()
        {
            plots = new List<bool> {false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            gold = 0;
            cropInventoryAmount = new List<int>();
            cropInventoryName = new List<string>();
            cropInventoryRarity = new List<int>();
            commission1Crop = "Potato";
            commission1QuantityDemanded = 25;
            commission2Crop = "Potato";
            commission2QuantityDemanded = 25;
            commission3Crop = "Potato";
            commission3QuantityDemanded = 25;
            plotsBought = 1;
            upgradesLevel = new List<int> { 1, 1, 1, 1, 1 };
            upgradesCost = new List<int> { 100, 100, 100, 500, 500 };
        }
    }

    public static UpdateSave Instance;
    public List<GameObject> plots;
    public storedValue gold;
    public List<GameObject> commissions;
    public storedValue plotsBought;
    public List<Upgrade> upgrades;

    public SaveFile playerSave = new SaveFile();
    public bool EncryptionEnabled = false;
    private IDataService DataService = new JsonDataService();

    private void Awake()
    {
        Instance = this;
    }

    public void ToggleEncryption(bool EncryptionEnabled)
    {
        EncryptionEnabled = !EncryptionEnabled;
    }

    public void SerializeJson()
    {
        updateAll();
        if (DataService.SaveData("/playerSaveFile.json", playerSave, EncryptionEnabled))
        {
            
        } else
        {
            Debug.LogError("Could not save file.");
        }
    }

    public void LoadJson()
    {
        try
        {
            playerSave = DataService.LoadData<SaveFile>("/playerSaveFile.json", EncryptionEnabled);
            Debug.Log(DataService.LoadData<SaveFile>("/playerSaveFile.json", EncryptionEnabled).plots[1]);
        } catch (Exception e)
        {
            Debug.LogError($"Could not read file.");
        }
    }

    public void LoadAll()
    {
        LoadJson();
        for (var i = 0; i < plots.Count; i++)
        {
            if (playerSave.plots[i])
            {
                plots[i].GetComponent<PlotBehaviour>().isLocked = true;
                plots[i].GetComponent<PlotBehaviour>().locked.SetActive(true);
            } else
            {
                plots[i].GetComponent<PlotBehaviour>().isLocked = false;
                plots[i].GetComponent<PlotBehaviour>().locked.SetActive(false);
            }
        }
        gold.value = playerSave.gold;

        foreach (var Crop in InventoryCropManager.Instance.Crops)
        {
            Crop.amount = 0;
        }
        InventoryCropManager.Instance.UpdateInventory();

        for (var i = 0; i< playerSave.cropInventoryName.Count; i++)
        {
            CropList.Instance.GetCrop(playerSave.cropInventoryName[i])[playerSave.cropInventoryRarity[i]].amount = playerSave.cropInventoryAmount[i];
        }

        commissions[0].GetComponent<CommissionManager>().crop = playerSave.commission1Crop;
        commissions[0].GetComponent<CommissionManager>().quantityDemanded = playerSave.commission1QuantityDemanded;
        commissions[1].GetComponent<CommissionManager>().crop = playerSave.commission2Crop;
        commissions[1].GetComponent<CommissionManager>().quantityDemanded = playerSave.commission2QuantityDemanded;
        commissions[2].GetComponent<CommissionManager>().crop = playerSave.commission3Crop;
        commissions[2].GetComponent<CommissionManager>().quantityDemanded = playerSave.commission3QuantityDemanded;
        foreach (var commission in commissions)
        {
            commission.GetComponent<CommissionManager>().updateCommissionDisplay();
        }
        plotsBought.value = playerSave.plotsBought;
        for (var i = 0; i < upgrades.Count; i++)
        {
            upgrades[i].level = playerSave.upgradesLevel[i];
            upgrades[i].cost = playerSave.upgradesCost[i];
        }
    }

    public void updateAll()
    {
        updatePlots();
        updateGold();
        updateCropInventory();
        updateCommissions();
        updatePlotsBought();
        updateUpgrades();
    }

    public void updatePlots()
    {
        for (var i = 0; i < plots.Count; i++)
        {
            playerSave.plots[i] = plots[i].GetComponent<PlotBehaviour>().isLocked;
        }
    }

    public void updateGold()
    {
        playerSave.gold = gold.value;
    }

    public void updateCropInventory()
    {
        playerSave.cropInventoryAmount = new List<int>();
        playerSave.cropInventoryName = new List<string>();
        playerSave.cropInventoryRarity = new List<int>();
        foreach (var Crop in InventoryCropManager.Instance.Crops)
        {
            playerSave.cropInventoryName.Add(Crop.name);
            playerSave.cropInventoryAmount.Add(Crop.amount);
            if (Crop.rarity == "Common")
            {
                playerSave.cropInventoryRarity.Add(0);
            }
            else if (Crop.rarity == "Uncommon")
            {
                playerSave.cropInventoryRarity.Add(1);
            }
            else if (Crop.rarity == "Rare")
            {
                playerSave.cropInventoryRarity.Add(2);
            }
            else
            {
                playerSave.cropInventoryRarity.Add(3);
            }
        }
    }

    public void updateCommissions()
    {
        playerSave.commission1Crop = commissions[0].GetComponent<CommissionManager>().crop;
        playerSave.commission1QuantityDemanded = commissions[0].GetComponent<CommissionManager>().quantityDemanded;
        playerSave.commission2Crop = commissions[1].GetComponent<CommissionManager>().crop;
        playerSave.commission2QuantityDemanded = commissions[1].GetComponent<CommissionManager>().quantityDemanded;
        playerSave.commission3Crop = commissions[2].GetComponent<CommissionManager>().crop;
        playerSave.commission3QuantityDemanded = commissions[2].GetComponent<CommissionManager>().quantityDemanded;
    }

    public void updatePlotsBought()
    {
        playerSave.plotsBought = plotsBought.value;
    }

    public void updateUpgrades()
    {
        playerSave.upgradesLevel = new List<int>();
        playerSave.upgradesCost = new List<int>();
        for (var i = 0; i < upgrades.Count; i++)
        {
            playerSave.upgradesLevel.Add(upgrades[i].level);
            playerSave.upgradesCost.Add(upgrades[i].cost);
        }
    }
}
