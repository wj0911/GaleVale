using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
 
public class DragHandler : MonoBehaviour {
    public Image scrollableObject;
    public void preventDrag() {
        scrollableObject.GetComponent<ScrollRect>().horizontal = false;
        scrollableObject.GetComponent<ScrollRect>().vertical = false;
    }

    public void allowDrag() {
        scrollableObject.GetComponent<ScrollRect>().horizontal = true;
        scrollableObject.GetComponent<ScrollRect>().vertical = true;
    }

    public void manageDrag(bool moveSelected) {
        if (moveSelected) {
            allowDrag();
        } else {
            preventDrag();
        }
    }
 
}