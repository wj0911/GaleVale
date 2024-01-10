using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotBuyManager : MonoBehaviour
{
    public TMP_Text plotMenuText;
    public storedValue gold, plotsBought;
    public GameObject selectedPlot;

    public void buyPlot() {
        PlotBehaviour selectedPlotBehaviour = selectedPlot.GetComponent<PlotBehaviour>();
        selectedPlotBehaviour.isLocked = false;
        selectedPlotBehaviour.locked.SetActive(false);
        plotsBought.value += 1;
        gameObject.SetActive(false);
    }

    public void buyPlotRequested() {
        int cost = 10 * plotsBought.value;
        if (cost <= gold.value) {
            buyPlot();
            gold.value -= cost;
        } else {
            plotMenuText.text = "Too poor!";
        }
    }

    public void updateDisplay() {
        int cost = 10 * plotsBought.value;
        plotMenuText.text = "Buy plot for " + cost.ToString() + "g?";
    }
}
