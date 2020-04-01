﻿using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public GameObject pressedEffect;

    public Renderer floorRenderer; 
    public Renderer pressedRenderer;

    public Color floorColor; 
    public Color grayColor;
    public Color pressedColor; 

    public bool isButton;

    public void setFloor(int index, int value) {

        if(value == -1) {
            gameObject.SetActive(false);
        }

        if(index % 2 == 0) {
            floorRenderer.material.color = grayColor;
        }

        else {
            floorRenderer.material.color = floorColor;
        }

        if(value == 2) {
            floorRenderer.material.color = pressedColor;
            isButton = true;
        }

        pressedRenderer.material.color = new Color(0, 0, 0, 0);

    }

}