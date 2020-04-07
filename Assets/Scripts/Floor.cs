﻿using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public const float INIT_ANIMATION = 0.6f;

    public Color floorColor;
    public Color objectiveColor; 
    public Color buttonColor;

    public MeshFilter floorMesh; 
    public MeshFilter buttonMesh; 

    public Renderer floorRenderer; 
    public MeshFilter floorMeshFilter;
    public FloorType type;

    public void setFloor(int value) {

        if(value == -1) {
            type = FloorType.EMPTY;
            gameObject.SetActive(false);
        }

        if(value >= 0) {
            type = FloorType.NORMAL;
            gameObject.SetActive(true);
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            floorRenderer.material.color = floorColor; 
        }

        if(value == 2) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = objectiveColor;
        }

        if(value == 3) {
            type = FloorType.BUTTON;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = buttonColor;
        }

        if(value == 4) {
            type = FloorType.INACTIVE;
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            floorRenderer.material.color = buttonColor;
        }

        if(value == 5) {
            type = FloorType.ACTIVE;
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            floorRenderer.material.color = buttonColor;
        }
        
    }

    public void initAnimation(float delay) {

        transform.DOLocalMoveY(5, INIT_ANIMATION).From().SetDelay(delay);      
        floorRenderer.material.DOFade(0, INIT_ANIMATION).From().SetDelay(delay);  
    
    }

}
