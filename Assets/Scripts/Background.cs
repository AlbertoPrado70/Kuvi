﻿using UnityEngine;
using DG.Tweening;

public class Background : MonoBehaviour {

    public const float BACKGROUND_CHANGE = 0.5f;

    public Color[] backgroundColor; 
   
    public void setBackgroundColor(int newColor) {
        Camera.main.DOColor(backgroundColor[newColor], BACKGROUND_CHANGE);
    }

}
