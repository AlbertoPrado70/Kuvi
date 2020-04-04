using UnityEngine;
using DG.Tweening;

public class LoadLevel : State {
 
    private Checkboard checkboard;

    public LoadLevel(Checkboard checkboard) {

        this.checkboard = checkboard;

    }

    public override void Tick() {

        setLevel(checkboard.actualLevel);
        checkboard.setState(checkboard.moveCubeState);

    }

    public void setLevel(int levelIndex) {

        foreach(Cube cube in checkboard.cubes) {
            Checkboard.Destroy(cube.gameObject);
        }

        checkboard.cubes.Clear();

        levelIndex = (levelIndex >= Level.json.Length) ? 0 : levelIndex; 
        JsonUtility.FromJsonOverwrite(Level.json[levelIndex].Replace('\'', '"'), checkboard.level);
        
        float delayAnimation = 0;

        for(int row = 0; row < Checkboard.LEVEL_SIZE; row++) {
            for(int column = 0; column < Checkboard.LEVEL_SIZE; column++) {
                
                checkboard.floor[row, column].setFloor(checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + column]);
                
                if(checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + column] != -1) {
                    checkboard.floor[row, column].initAnimation(delayAnimation);
                    delayAnimation += 0.05f;
                }

                if(checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + column] == 1) {

                    GameObject cube = Checkboard.Instantiate(checkboard.cubePrefab, new Vector3(row, 0.75f, column), Quaternion.identity, checkboard.transform);
                    cube.name = "Cube" + row + column;
                    cube.GetComponent<Cube>().setPosition(row, column); 
                    cube.GetComponent<Cube>().initAnimation();
    
                    checkboard.cubes.Add(cube.GetComponent<Cube>());

                }
                
            }
        }

    }
    
}
