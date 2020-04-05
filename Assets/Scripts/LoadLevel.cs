using UnityEngine;
using DG.Tweening;

public class LoadLevel : State {
 
    private Kuvi kuvi;

    public LoadLevel(Kuvi kuvi) {

        this.kuvi = kuvi;
        kuvi.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 - 200, Camera.main.farClipPlane / 2));
    
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

                    cube.transform.localPosition = new Vector3(row * floorSize.x, floorSize.y, column * floorSize.x);
                    cube.name = "Cube" + row + column;
                    cube.GetComponent<Cube>().setPosition(row, column); 
                    cube.GetComponent<Cube>().initAnimation(1 + delayAnimation);
    
                    kuvi.cubes.Add(cube.GetComponent<Cube>());

                }
                
            }
        }


    }

    
}
