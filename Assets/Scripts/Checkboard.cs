using UnityEngine;
using System.Collections.Generic;

public class Checkboard : MonoBehaviour {
    
    public const int LEVEL_SIZE = 5;  

    public GameObject floorPrefab;
    public GameObject cubePrefab; 

    public GameObject[,] floor;
    public List<Cube> cubes;

    public LoadLevel loadLevelState;
    public Iddle iddleState; 
    public State actualState; 

    void Start() {
        
        floor = new GameObject[LEVEL_SIZE, LEVEL_SIZE];
        cubes = new List<Cube>();

        Vector3 prefabPosition = new Vector3(0, 0, 0);

        for(int row = 0; row < LEVEL_SIZE; row++) {
            for(int column = 0; column < LEVEL_SIZE; column++) {
                
                prefabPosition.Set(row, 0, column);
                floor[row, column] = Instantiate(floorPrefab, prefabPosition, Quaternion.identity, transform);
                floor[row, column].hideFlags = HideFlags.HideInHierarchy;
                floor[row, column].SetActive(false);
                
                if((row * LEVEL_SIZE + column) % 2 == 0) {
                    floor[row, column].GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0.9f, 1);
                }

            }
        }

        loadLevelState = new LoadLevel(this);
        iddleState = new Iddle(this);
        setState(loadLevelState);

    }

    void Update() {
        
        actualState.Tick();

    }

    public void setState(State state) {

        actualState = state;

    }

 
}
