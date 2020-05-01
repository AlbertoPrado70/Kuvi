using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.Advertisements;

public class Kuvi : MonoBehaviour {
    
    public const int LEVEL_SIZE = 7;

    public GameObject floorPrefab;
    public GameObject cubePrefab; 
    public MenuController menuController;

    public Floor[,] floor;
    public List<Cube> cubes;

    public Level level; 
    public Solver solver;
    public Preferences preferences; 

    public LoadLevel loadLevelState;
    public MoveCube moveCubeState; 
    public LevelComplete levelCompleteState;
    public State actualState; 

    public Background background; 

    void Awake() {

        DOTween.Init(true);

        floor = new Floor[LEVEL_SIZE, LEVEL_SIZE];
        cubes = new List<Cube>();

        Vector3 position = new Vector3(0, 0, 0);
        Vector3 floorSize = floorPrefab.GetComponent<Floor>().floorRenderer.bounds.size; 

        for(int row = 0; row < LEVEL_SIZE; row++) {
            for(int column = 0; column < LEVEL_SIZE; column++) {   

                position.Set(floorSize.x * row, 0, floorSize.z * column);

                GameObject f = Instantiate(floorPrefab, position, Quaternion.identity, transform);
                floor[row, column] = f.GetComponent<Floor>();

            }
        }

        level = new Level();
        solver = new Solver();
        preferences = new Preferences(); 

        AudioListener.volume = (preferences.muted) ? 0 : 1;

        loadLevelState = new LoadLevel(this);
        moveCubeState = new MoveCube(this);
        levelCompleteState = new LevelComplete(this);
        
        setState(loadLevelState);
        
        Advertisement.Initialize("3580984", true);
        
    }

    void Update() {
        actualState.Tick();
    }

    public void setState(State state) {

        if(actualState != null) {
            actualState.onExit();
        }

        actualState = state;
        actualState.onEnter();
        
    }
 
    public int totalTweens() {

        int activeTweens = 0; 
        
        foreach(Cube cube in cubes) {
            activeTweens += (cube.isTweening) ? 1 : 0; 
        }

        foreach(Floor floor in floor) {
            activeTweens += (floor.isTweening) ? 1 : 0; 
        }

        return(activeTweens); 

    }

}