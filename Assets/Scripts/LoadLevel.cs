﻿using UnityEngine;

public class LoadLevel : State {
 
    public const float LEVEL_PADDING = 0.25f;

    private Kuvi kuvi;

    public LoadLevel(Kuvi kuvi) {

        this.kuvi = kuvi;

        setCameraPosition();
    
    }

    public override void Tick() {

        setLevel(kuvi.actualLevel);
        kuvi.setState(kuvi.moveCubeState);

    }

    public void setLevel(int levelIndex) {

        foreach(Cube cube in kuvi.cubes) {
            Kuvi.Destroy(cube.gameObject);
        }

        kuvi.cubes.Clear();

        levelIndex = (levelIndex >= Level.json.Length) ? 0 : levelIndex; 
        JsonUtility.FromJsonOverwrite(Level.json[levelIndex].Replace('\'', '"'), kuvi.level);
        
        float delayAnimation = 0;

        for(int row = 0; row < Kuvi.LEVEL_SIZE; row++) {
            for(int column = 0; column < Kuvi.LEVEL_SIZE; column++) {
                
                kuvi.floor[row, column].setFloor(kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column]);
                
                if(kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] != -1) {
                    kuvi.floor[row, column].initAnimation(delayAnimation);
                    delayAnimation += 0.1f;
                }

                if(kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] == 1) {

                    Vector3 floorSize = kuvi.floorPrefab.GetComponent<Floor>().floorRenderer.bounds.size;

                    GameObject cube = Kuvi.Instantiate(kuvi.cubePrefab, Vector3.zero, Quaternion.identity, kuvi.transform);

                    cube.transform.localPosition = new Vector3(row * floorSize.x, 0.6f, column * floorSize.x);
                    cube.name = "Cube" + row + column;
                    cube.GetComponent<Cube>().setPosition(row, column); 
                    cube.GetComponent<Cube>().initAnimation(Floor.INIT_ANIMATION + delayAnimation);
    
                    kuvi.cubes.Add(cube.GetComponent<Cube>());

                }
                
            }
        }

        kuvi.background.setColor();
        kuvi.menuController.showLevelMessage(kuvi.level.message);

    }

    public void setCameraPosition() {

        Bounds levelBounds = new Bounds(Vector3.zero, Vector3.zero);

        float floorSize = kuvi.floor[0, 0].floorRenderer.bounds.size.x * Kuvi.LEVEL_SIZE;

        float cameraHeight = 2 * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float levelWidth = Mathf.Sqrt(Mathf.Pow(floorSize, 2) + Mathf.Pow(floorSize, 2));

        float newSize = cameraWidth / (levelWidth + LEVEL_PADDING);

        kuvi.transform.localScale = kuvi.transform.localScale * newSize;

        Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane / 2));

        kuvi.transform.position = new Vector3(center.x, center.y - levelWidth / 2, center.z);

    }

}
