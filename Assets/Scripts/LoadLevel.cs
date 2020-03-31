using UnityEngine;

public class LoadLevel : State {
 
    Checkboard checkboard;

    public LoadLevel(Checkboard checkboard) {

        this.checkboard = checkboard;

    }

    public override void Tick() {

        setLevel(checkboard.actualLevel);
        checkboard.setState(checkboard.iddleState);

    }

    public void setLevel(int levelIndex) {

        levelIndex = (levelIndex >= Level.json.Length) ? 0 : levelIndex; 
        JsonUtility.FromJsonOverwrite(Level.json[levelIndex].Replace('\'', '"'), checkboard.level);
        
        for(int row = 0; row < Checkboard.LEVEL_SIZE; row++) {
            for(int column = 0; column < Checkboard.LEVEL_SIZE; column++) {
                
                if(checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + column] > 0) {
                    checkboard.floor[row, column].SetActive(true);
                }

                if(checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + column] == 2) {
                    GameObject cube = Checkboard.Instantiate(checkboard.cubePrefab, new Vector3(row, 0.75f, column), Quaternion.identity, checkboard.transform);
                    cube.name = "Cube" + row + column;
                    cube.GetComponent<Cube>().setPosition(row, column); 
                    cube.GetComponent<Renderer>().material.color = new Color(0.35f, 0.35f, 0.65f, 1);
                    checkboard.cubes.Add(cube.GetComponent<Cube>());
                }
                
            }
        }

    }
    
}
