using UnityEngine;
using UnityEngine.Advertisements;

public class LevelComplete : State {

    public enum CompleteState {SET_STATE, SET_COMPLETE_ANIMATION, COMPLETE_LEVEL};
    
    private Kuvi kuvi;

    private CompleteState completeState; 
    public bool levelCompleted;

    public LevelComplete(Kuvi kuvi) {

        this.kuvi = kuvi;
    
        completeState = CompleteState.SET_STATE; 
        levelCompleted = false; 
    
    }

    public override void onEnter() {

        bool allButtonsPressed = true; 

        foreach(Cube cube in kuvi.cubes) {
            allButtonsPressed = (kuvi.floor[cube.row, cube.column].type == FloorType.OBJETIVE) ? allButtonsPressed : false; 
        }

        levelCompleted = allButtonsPressed; 

    }

    public override void Tick() {

        if(completeState == CompleteState.SET_STATE) {

            if(!levelCompleted) {            
                kuvi.setState(kuvi.moveCubeState);
            }

            if(levelCompleted) {
                completeState = CompleteState.SET_COMPLETE_ANIMATION;
            }

        }

        if(completeState == CompleteState.SET_COMPLETE_ANIMATION && kuvi.totalTweens() == 0) {
            
            foreach(Cube cube in kuvi.cubes) {
                cube.completeAnimation();
            }

            completeState = CompleteState.COMPLETE_LEVEL;

        }

        if(completeState == CompleteState.COMPLETE_LEVEL && kuvi.totalTweens() == 0) {

            levelCompleted = false; 
            completeState = CompleteState.SET_STATE;

            // Mostramos un anuncio 
            // Advertisement.Show();

            // Cambiamos el fondo 
            kuvi.background.setBackgroundColor(Random.Range(0, kuvi.background.backgroundColor.Length));

            if(kuvi.moveCubeState.autosolve) {
                kuvi.moveCubeState.autosolve = false; 
            }

            if(kuvi.preferences.actualLevel < Level.json.Length - 1) {
                kuvi.preferences.actualLevel++;
            }

            kuvi.preferences.saveCompletedLevel(); 
            kuvi.setState(kuvi.loadLevelState); 

            // Move Debug Solution
            // Debug.Log(kuvi.moveCubeState.levelSolution); 
            kuvi.moveCubeState.levelSolution = "";

        }

    }
    
}