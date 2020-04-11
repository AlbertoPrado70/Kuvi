using UnityEngine;

public class LoadLevel : State {
 
    public const float LEVEL_PADDING = 0.05f;

    private Kuvi kuvi;

    public LoadLevel(Kuvi kuvi) {
        this.kuvi = kuvi;
    }

    public override void onEnter() {
        kuvi.menuController.fadeOutPanel();
        setLevel(kuvi.actualLevel);
        setCameraPosition();
    }

    public override void Tick() {
        if(kuvi.totalTweens() == 0) {
            kuvi.setState(kuvi.moveCubeState);
        }
    }

    public void setLevel(int levelIndex) {

        foreach(Cube cube in kuvi.cubes) {
            Kuvi.Destroy(cube.gameObject);
        }

        kuvi.cubes.Clear();
        kuvi.menuController.stopMessageAnimations();

        levelIndex = (levelIndex >= Level.json.Length) ? Level.json.Length - 1 : levelIndex; 
        JsonUtility.FromJsonOverwrite(Level.json[levelIndex].Replace('\'', '"'), kuvi.level);
        
        float delayAnimation = 0;

        Vector3 cubePosition = new Vector3();

        for(int row = 0; row < Kuvi.LEVEL_SIZE; row++) {
            for(int column = 0; column < Kuvi.LEVEL_SIZE; column++) {

                kuvi.floor[row, column].setFloor(kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column]);

                if(kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] != -1) {

                    kuvi.floor[row, column].initAnimation(delayAnimation);
                    
                    delayAnimation += 0.1f;

                }


                if((row * Kuvi.LEVEL_SIZE + column) % 2 == 0 && kuvi.floor[row, column].type == FloorType.NORMAL) {
                    kuvi.floor[row, column].floorRenderer.material.color = kuvi.floor[row, column].grayFloorColor;
                }

                if(kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] == 1) {

                    Vector3 floorSize = kuvi.floorPrefab.GetComponent<Floor>().floorRenderer.bounds.size;
                    GameObject cube = Kuvi.Instantiate(kuvi.cubePrefab, Vector3.zero, Quaternion.identity, kuvi.transform);

                    cubePosition.Set(row * floorSize.x, 0.6f, column * floorSize.x);
                    cube.transform.localPosition = cubePosition;
                    
                    Cube cubeComponent = cube.GetComponent<Cube>();
                    cubeComponent.setPosition(row, column); 
                    cubeComponent.initAnimation(Floor.INIT_ANIMATION + delayAnimation);
    
                    kuvi.cubes.Add(cubeComponent);

                }
                
            }
        }

        kuvi.menuController.setLevelText((kuvi.actualLevel + 1).ToString());
        kuvi.menuController.showLevelMessage(kuvi.level.message);

    }

    public void setCameraPosition() {

        Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane / 2));

        float cameraHeight = 2 * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;        
        float floorDiagonal = kuvi.floor[0, 0].floorRenderer.bounds.size.x * Mathf.Sqrt(2);
        float newSize = cameraWidth / (floorDiagonal * Kuvi.LEVEL_SIZE + LEVEL_PADDING);

        kuvi.transform.localScale = kuvi.transform.localScale * newSize;
        kuvi.transform.position = new Vector3(center.x, center.y - (floorDiagonal * newSize * 3), center.z);

    }


}
