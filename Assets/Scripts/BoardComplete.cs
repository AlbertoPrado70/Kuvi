using UnityEngine;
using DG.Tweening;

public class BoardComplete : State {

    private Checkboard checkboard;

    public BoardComplete(Checkboard checkboard) {

        this.checkboard = checkboard;

    }

    public override void Tick() {

        if(!isBoardCompleted()) {
            checkboard.setState(checkboard.moveCubeState);
        }

        // else {
        //     checkboard.setState(checkboard.loadLevelState);
        // }

    }

    public bool isBoardCompleted() {

        bool isCompleted = true; 

        foreach(Cube cube in checkboard.cubes) {

            if(checkboard.floor[cube.row, cube.column].isButton) {
                cube.GetComponent<Renderer>().material.DOColor(new Color(0.5683072f, 0.5756204f, 0.9339623f), 0.5f).SetDelay(0.5f);
            }

            else {
                cube.GetComponent<Renderer>().material.DOColor(new Color(0.35f, 0.35f, 0.35f, 1), 0.5f).SetDelay(0.25f);
                isCompleted = false; 
            }

        }

        if(isCompleted) {
            foreach(Cube cube in checkboard.cubes) {
                checkboard.floor[cube.row, cube.column].pressedAnimation();
            }
        }

        return(isCompleted);

    }
    
}
