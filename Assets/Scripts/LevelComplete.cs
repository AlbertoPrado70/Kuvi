public class LevelComplete : State {

    private Kuvi kuvi;
    public bool levelCompleted;

    public LevelComplete(Kuvi kuvi) {
        this.kuvi = kuvi;
        levelCompleted = false; 
    }

    public override void Tick() {

        if(!levelCompleted) {

            bool allButtonsPressed = true; 

            foreach(Cube cube in kuvi.cubes) {
                if(kuvi.floor[cube.row, cube.column].type == FloorType.OBJETIVE) {
                    cube.colorAnimation(cube.objectiveColor);
                }
                else {
                    cube.colorAnimation(cube.cubeColor);
                    allButtonsPressed = false; 
                }
            }

            levelCompleted = allButtonsPressed;

        }

        if(!levelCompleted) {
            
            kuvi.setState(kuvi.moveCubeState);
            
        }

        if(levelCompleted && kuvi.totalTweens() == 0) {

            foreach(Cube cube in kuvi.cubes) {
                cube.completeAnimation();
            }

            kuvi.levelCompleteState.levelCompleted = false; 
            kuvi.actualLevel++;

            kuvi.setState(kuvi.loadLevelState);
            
        }


    }
    
}
