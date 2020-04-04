using UnityEngine;
using DG.Tweening;

public class LoadLevel : State {
 
    private Kuvi kuvi;

    public LoadLevel(Kuvi kuvi) {

        this.kuvi = kuvi;

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

                    GameObject cube = Kuvi.Instantiate(kuvi.cubePrefab, new Vector3(row, 0.75f, column), Quaternion.identity, kuvi.transform);
                    cube.name = "Cube" + row + column;
                    cube.GetComponent<Cube>().setPosition(row, column); 
                    cube.GetComponent<Cube>().initAnimation();
    
                    kuvi.cubes.Add(cube.GetComponent<Cube>());

                }
                
            }
        }

    }
    
}
