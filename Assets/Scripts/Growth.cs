using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Growth : MonoBehaviour
{
public SpriteRenderer spriteRenderer;
public Sprite empty, seeded, halfgrown, grown;
public int State, growth, frames;
public int growthSpeed, soilQuality;
public GameObject gardenTools;

void StateChange(int tool)
{
    if (tool == -1) {
        if (State == 1) {
            spriteRenderer.sprite = halfgrown;
            State = 2;
            Debug.Log("Half");
        } else if (State == 2) {
            spriteRenderer.sprite = grown;
            State = 3;
            Debug.Log("Grown");
        } else {
            Debug.Log("Already grown!");
        }
    } else if (tool == 1 && State == 0) {
        spriteRenderer.sprite = seeded;
        State = 1;
    } else if (tool == 2 && State == 3) {
        spriteRenderer.sprite = empty;
        State = 0;
    } else {
        Debug.Log("Nope! :p");
    }
}

    void Start() {
        State = 0;
        growth = 0;
        frames = 0;
    }
    void Update() {
        frames++;
        Random rnd = new Random();
        if (frames % 1000 == 0) {
            int num = rnd.Next(0 + growthSpeed, 1000);
            if (growth + num >= 1000) {
                StateChange(-1);
                growth = 0;
            } else {
                growth += 1;
            }
        }
    }

    void OnMouseDown() {
        int tool = gardenTools.GetComponent<GardenTools>().toolbarInt;
        if (tool != 0) {
            StateChange(tool);
        }
    }
}