using UnityEngine;
using System.Collections.Generic;

public class Checkboard : MonoBehaviour {
    
    public const int LEVEL_SIZE = 8;

    public GameObject floorPrefab;
    public GameObject cubePrefab; 
    public GameObject completeEffect;

    public Floor[,] floor;
    public List<Cube> cubes;

    public Level level; 
    public int actualLevel;

    public LoadLevel loadLevelState;
    public MoveCube moveCubeState; 
    public BoardComplete boardCompleteState;
    public State actualState; 

    void Start() {
        
        floor = new Floor[LEVEL_SIZE, LEVEL_SIZE];
        cubes = new List<Cube>();

        Vector3 prefabPosition = new Vector3(0, 0, 0);

        for(int row = 0; row < LEVEL_SIZE; row++) {
            for(int column = 0; column < LEVEL_SIZE; column++) {
                
                prefabPosition.Set(row, 0, column);
                GameObject f = Instantiate(floorPrefab, prefabPosition, Quaternion.identity, transform);
                // f.hideFlags = HideFlags.HideInHierarchy;
                floor[row, column] = f.GetComponent<Floor>();

            }
        }

        level = new Level();
        actualLevel = 1; 

        loadLevelState = new LoadLevel(this);
        moveCubeState = new MoveCube(this);
        boardCompleteState = new BoardComplete(this);
        setState(loadLevelState);

    }

    void Update() {
        
        actualState.Tick();

    }

    public void setState(State state) {

        actualState = state;

    }

    public void printMatrix() {

        string s = "Level " + actualLevel + "\n";

        for(int row = 0; row < LEVEL_SIZE; row++) {
            for(int column = 0; column < LEVEL_SIZE; column++) {
                s += level.matrix[row * LEVEL_SIZE + column];
            }
            s += "\n";
        }

        Debug.Log(s);

    }
 
}
