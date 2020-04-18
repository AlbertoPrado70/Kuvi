using UnityEngine;

public class LoadLevel : State {
 
    public enum LoadLevelState {FADE_FLOOR, ANIMATE_FLOOR, SET_STATE};
    public const float LEVEL_PADDING = 0.05f;
    
    private Kuvi kuvi;
    
    private bool isPanelFadedOut; 
    private LoadLevelState loadState; 

    public LoadLevel(Kuvi kuvi) {

        this.kuvi = kuvi;

        isPanelFadedOut = false; 
        loadState = LoadLevelState.FADE_FLOOR;

    }

    public override void onEnter() {

        if(!isPanelFadedOut) {
            isPanelFadedOut = true; 
            kuvi.menuController.fadeOutPanel();
        }

        setLevel(kuvi.actualLevel);
        setCameraPosition();

        kuvi.solver.parseSolution(kuvi.actualLevel);
        kuvi.menuController.stopMessageAnimations();

    }

    public override void Tick() {

        if(loadState == LoadLevelState.FADE_FLOOR) {

            for(int row = 0; row < Kuvi.LEVEL_SIZE; row++) {
                for(int column = 0; column < Kuvi.LEVEL_SIZE; column++) {
                    if(kuvi.floor[row, column].value != kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] && kuvi.floor[row, column].type != FloorType.EMPTY) {
                        kuvi.floor[row, column].fadeOutAnimation();
                    }
                }
            }

            loadState = LoadLevelState.ANIMATE_FLOOR; 

        }

        if(loadState == LoadLevelState.ANIMATE_FLOOR &&  kuvi.totalTweens() == 0) {

            float delayAnimation = 0; 
            Vector3 cubePosition = new Vector3();

            for(int row = 0; row < Kuvi.LEVEL_SIZE; row++) {
                for(int column = 0; column < Kuvi.LEVEL_SIZE; column++) {

                    int matrixIndex = row * Kuvi.LEVEL_SIZE + column;

                    if(kuvi.floor[row, column].value != kuvi.level.matrix[matrixIndex]) {

                        kuvi.floor[row, column].setFloor(kuvi.level.matrix[matrixIndex]);
                        kuvi.floor[row, column].initAnimation(delayAnimation);

                        delayAnimation += (kuvi.level.matrix[matrixIndex] != -1) ? 0.1f : 0;

                    }

                    if((matrixIndex) % 2 == 0 && kuvi.floor[row, column].type == FloorType.NORMAL) {
                        kuvi.floor[row, column].floorRenderer.material.color = kuvi.floor[row, column].grayFloorColor;
                    }

                    if(kuvi.level.matrix[matrixIndex] == 1) {

                        Vector3 floorSize = kuvi.floorPrefab.GetComponent<Floor>().floorRenderer.bounds.size;
                        GameObject cube = Kuvi.Instantiate(kuvi.cubePrefab, Vector3.zero, Quaternion.identity, kuvi.transform);

                        cubePosition.Set(row * floorSize.x, 0.6f, column * floorSize.x);
                        cube.transform.localPosition = cubePosition;
                        
                        Cube cubeComponent = cube.GetComponent<Cube>();
                        cubeComponent.set(row, column); 
                        cubeComponent.initAnimation(Floor.INIT_ANIMATION + delayAnimation);
        
                        kuvi.cubes.Add(cubeComponent);

                    }

                }
            }
        
            loadState = LoadLevelState.SET_STATE;             

        }

        if(loadState == LoadLevelState.SET_STATE && kuvi.totalTweens() == 0) {
            kuvi.menuController.showLevelMessage(kuvi.level.message);
            kuvi.menuController.setMenuActive(true);
            kuvi.setState(kuvi.moveCubeState); 
        }

    }

    public override void onExit() {
        loadState = LoadLevelState.FADE_FLOOR;
    }

    public void setLevel(int levelIndex) {

        foreach(Cube cube in kuvi.cubes) {
            Kuvi.Destroy(cube.gameObject);
        }

        kuvi.cubes.Clear();

        levelIndex = (levelIndex >= Level.json.Length) ? Level.json.Length - 1 : levelIndex; 
        JsonUtility.FromJsonOverwrite(Level.json[levelIndex].Replace('\'', '"'), kuvi.level);
        
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
