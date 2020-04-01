using UnityEngine;
using DG.Tweening;

public class BoardComplete : State {

    private Checkboard checkboard;

    public BoardComplete(Checkboard checkboard) {

        this.checkboard = checkboard;

    }

    public override void Tick() {

        isBoardCompleted();
        checkboard.setState(checkboard.moveCubeState);
        

    }

    public void isBoardCompleted() {

        foreach(Cube cube in checkboard.cubes) {

            if(checkboard.floor[cube.row, cube.column].isButton) {
                cube.GetComponent<Renderer>().material.DOColor(new Color(0.5683072f, 0.5756204f, 0.9339623f), 0.5f).SetDelay(0.5f);
            }

            else {
                cube.GetComponent<Renderer>().material.DOColor(new Color(0.5f, 0.5f, 0.5f), 0.5f).SetDelay(0.25f);
            }

        }

    }
    
}
