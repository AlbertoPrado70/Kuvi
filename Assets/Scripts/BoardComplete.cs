using UnityEngine;
using DG.Tweening;

public class BoardComplete : State {

    private Checkboard checkboard;
    public bool completeAnimation;

    public BoardComplete(Checkboard checkboard) {

        this.checkboard = checkboard;
        completeAnimation = false; 

    }

    public override void Tick() {

        bool isCompleted = true; 

        foreach(Cube cube in checkboard.cubes) {

            if(checkboard.floor[cube.row, cube.column].isButton) {
                cube.cubeRenderer.material.DOColor(Color.red, 1).SetDelay(Cube.MOVE_DURATION);
            }

            else {
                cube.cubeRenderer.material.DOColor(cube.cubeColor, 1);
                isCompleted = false;
            }

        }

        if(isCompleted && !completeAnimation) {
            
            foreach(Cube cube in checkboard.cubes) {
                checkboard.floor[cube.row, cube.column].pressedAnimation();
            }

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
