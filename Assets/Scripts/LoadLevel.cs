﻿using UnityEngine;

public class LoadLevel : State {
 
    public const float LEVEL_PADDING = 0.05f;

    private Kuvi kuvi;

    public LoadLevel(Kuvi kuvi) {
        this.kuvi = kuvi;
        setCameraPosition();
    }

    public override void Tick() {
        setLevel(kuvi.actualLevel);
        setCameraPosition();
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

                if((row * Kuvi.LEVEL_SIZE + column) % 2 == 0 && kuvi.floor[row, column].type == FloorType.NORMAL) {
                    kuvi.floor[row, column].floorRenderer.material.color = new Color(0.95f, 0.95f, 0.95f, 1);
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

        kuvi.menuController.setLevelText((kuvi.actualLevel + 1).ToString());
        kuvi.menuController.showLevelMessage(kuvi.level.message);

    }

    public void setCameraPosition() {

        // Obtenemos el centro de la camara
        Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane / 2));

        // Calculamos las dimensiones de la camara
        float cameraHeight = 2 * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;        

        // Escalamos el contenedor
        float floorDiagonal = kuvi.floor[0, 0].floorRenderer.bounds.size.x * Mathf.Sqrt(2);
        float newSize = cameraWidth / (floorDiagonal * Kuvi.LEVEL_SIZE + LEVEL_PADDING);

        // Centramos el contenedor
        kuvi.transform.localScale = kuvi.transform.localScale * newSize;
        kuvi.transform.position = new Vector3(center.x, center.y - (floorDiagonal * newSize * 3), center.z);

    }


}
