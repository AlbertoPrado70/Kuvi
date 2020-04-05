using UnityEngine;
using DG.Tweening;

public class LevelComplete : State {

    private Kuvi kuvi;

    public LevelComplete(Kuvi kuvi) {

        this.kuvi = kuvi;

    }

    public override void Tick() {

        bool levelComplete = true; 

        foreach(Cube cube in kuvi.cubes) {
            if(kuvi.floor[cube.row, cube.column].type == FloorType.OBJETIVE) {
                cube.colorAnimation(cube.objectiveColor, 0.5f);
            }
            else {
                cube.colorAnimation(cube.cubeColor, 0);
                levelComplete = false; 
            }
        }

        if(levelComplete) {
            foreach(Cube cube in kuvi.cubes) {
                cube.completeAnimation();
            }
        }

        kuvi.setState(kuvi.moveCubeState);

    }
    
}
