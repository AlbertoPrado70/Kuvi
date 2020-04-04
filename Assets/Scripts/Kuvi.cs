﻿using UnityEngine;
using System.Collections.Generic;

public class Kuvi : MonoBehaviour {
    
    public const int LEVEL_SIZE = 8;

    public GameObject floorPrefab;
    public GameObject cubePrefab; 

    public Floor[,] floor;
    public List<Cube> cubes;

    public Level level; 
    public int actualLevel;

    public LoadLevel loadLevelState;
    public MoveCube moveCubeState; 
    public LevelComplete boardCompleteState;
    public State actualState; 

    void Start() {
        
        floor = new Floor[LEVEL_SIZE, LEVEL_SIZE];
        cubes = new List<Cube>();

        Vector3 position = new Vector3(0, 0, 0);
        Vector3 floorSize = floorPrefab.GetComponent<Floor>().floorRenderer.bounds.size; 

        for(int row = 0; row < LEVEL_SIZE; row++) {
            for(int column = 0; column < LEVEL_SIZE; column++) {   

                position.Set(floorSize.x * row, 0, floorSize.z * column);

                GameObject f = Instantiate(floorPrefab, position, Quaternion.identity, transform);
                floor[row, column] = f.GetComponent<Floor>();

            }
        }

        level = new Level();
        actualLevel = 1; 

        loadLevelState = new LoadLevel(this);
        moveCubeState = new MoveCube(this);
        boardCompleteState = new LevelComplete(this);
        setState(loadLevelState);

    }

    void Update() {
        
        actualState.Tick();

    }

    public void setState(State state) {

        actualState = state;

    }
 
}
