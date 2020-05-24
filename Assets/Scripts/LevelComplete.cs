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
            if(cube.cubeColor != CubeColor.NONE) {
                allButtonsPressed = (kuvi.floor[cube.row, cube.column].cubeColor == cube.cubeColor) ? allButtonsPressed : false; 
            }
        }

        levelCompleted = allButtonsPressed; 

        // Ponemos el numero de movimientos
        Debug.Log("incrementando movimientos: " + kuvi.moveCubeState.totalMoves);
        kuvi.menuController.setLevelIndicator((kuvi.preferences.actualLevel + 1) + " - " + kuvi.moveCubeState.totalMoves);

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
            
            // Iniciamos el SFX de completado
            kuvi.completeSFX.Play();

            foreach(Cube cube in kuvi.cubes) {
                cube.completeAnimation();
            }

            completeState = CompleteState.COMPLETE_LEVEL;

        }

        if(completeState == CompleteState.COMPLETE_LEVEL && kuvi.totalTweens() == 0) {

            levelCompleted = false; 
            completeState = CompleteState.SET_STATE;

            // Si usaron autosolve incrementamos el contador de anuncios
            if(kuvi.moveCubeState.autosolve) {
                kuvi.moveCubeState.autosolve = false; 
                kuvi.preferences.adCount += 4;
            }

            // Mostramos un anuncio 
            kuvi.preferences.adCount++; 
            if(kuvi.preferences.adCount >= 5 && !kuvi.preferences.isPremium) {
                kuvi.preferences.adCount = 0;
                kuvi.preferences.saveAdCount();
                Advertisement.Show();
            }

            Debug.Log("AdCount: " + kuvi.preferences.adCount);

            // Cambiamos el fondo 
            kuvi.background.setBackgroundColor(Random.Range(0, kuvi.background.backgroundColor.Length));

            // Avanzamos de nivel
            if(kuvi.preferences.actualLevel < Level.json.Length - 1) {
                kuvi.preferences.actualLevel++;
            }

            kuvi.preferences.saveCompletedLevel(); 
            kuvi.setState(kuvi.loadLevelState); 

            // Imprime la solución del nivel
            // Debug.Log(kuvi.moveCubeState.levelSolution); 
            // kuvi.moveCubeState.levelSolution = "";

        }

    }
    
}