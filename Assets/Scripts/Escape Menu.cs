using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenu;

    public void openEscapeMenu() {
        escapeMenu.SetActive(true);
    }

    void Update() {
        if (Input.GetKey("escape")) {
            openEscapeMenu();
        }
    }
}
