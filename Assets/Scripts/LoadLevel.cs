using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class LoadLevel : State {

    Level level;
    GameObject[,] floor; 
    List<Cube> cubes;
    Checkboard checkboard;

    public LoadLevel(Checkboard checkboard) {

        level = new Level();
        floor = checkboard.floor;
        cubes = checkboard.cubes;
        this.checkboard = checkboard;

    }

    public override void Tick() {

        setLevel(0);
        checkboard.setState(checkboard.iddleState);

    }

    public void setLevel(int levelIndex) {

        levelIndex = (levelIndex >= Level.json.Length) ? 0 : levelIndex; 
        JsonUtility.FromJsonOverwrite(Level.json[levelIndex].Replace('\'', '"'), level);
        
        for(int row = 0; row < Checkboard.LEVEL_SIZE; row++) {
            for(int column = 0; column < Checkboard.LEVEL_SIZE; column++) {
                
                if(level.cubes[row * Checkboard.LEVEL_SIZE + column] > 0) {
                    floor[row, column].SetActive(true);
                }

                if(level.cubes[row * Checkboard.LEVEL_SIZE + column] == 2) {
                    GameObject cube = Checkboard.Instantiate(checkboard.cubePrefab, new Vector3(row, 0.75f, column), Quaternion.identity, checkboard.transform);
                    cube.GetComponent<Renderer>().material.color = new Color(0.35f, 0.35f, 0.65f, 1);
                    cubes.Add(cube.GetComponent<Cube>());
                }
                
            }
        }

    }
    
}
