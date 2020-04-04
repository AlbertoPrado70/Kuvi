using UnityEngine;
using DG.Tweening;

public class LevelComplete : State {

    private Kuvi checkboard;
    public bool completeAnimation;

    public LevelComplete(Kuvi checkboard) {

        this.checkboard = checkboard;
        completeAnimation = false; 

    }

    public override void Tick() {

        bool isCompleted = true; 

        foreach(Cube cube in checkboard.cubes) {

            if(checkboard.floor[cube.row, cube.column].type == FloorType.OBJETIVE) {
                cube.cubeRenderer.material.DOColor(new Color(0.5f, 0.5f, 0.8f, 1), 1).SetDelay(Cube.MOVE_DURATION);
            }

            else {
                cube.cubeRenderer.material.DOColor(cube.cubeColor, 1);
                isCompleted = false;
            }

        }

        if(isCompleted && !completeAnimation) {
            
            // foreach(Cube cube in checkboard.cubes) {
            //     checkboard.floor[cube.row, cube.column].pressedAnimation();
            // }

            completeAnimation = true; 

        }

        if(isCompleted && completeAnimation) {

            if(Input.GetMouseButtonDown(0)) {
                checkboard.setState(checkboard.loadLevelState);
                completeAnimation = false;
            }

        }

        if(!isCompleted) {
            checkboard.setState(checkboard.moveCubeState);
        }

    }
    
}
