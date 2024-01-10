using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetValueFromDropdown : MonoBehaviour
{
    public static GetValueFromDropdown Instance;
    public TMP_Dropdown dropdown;
    public List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

    private void Awake()
    {
        Instance = this;
    }

    public string GetDropdownValue() {
        int pickedEntryIndex = dropdown.value;
        string selectedOption = dropdown.options[pickedEntryIndex].text;
        return selectedOption;
    }

    public void AddNewSeed() {
        dropdown.AddOptions(options);
    }
}
