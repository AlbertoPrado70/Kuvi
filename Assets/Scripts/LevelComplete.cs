public class LevelComplete : State {

    private Kuvi kuvi;
    public bool levelCompleted;

    public LevelComplete(Kuvi kuvi) {

        this.kuvi = kuvi;
        levelCompleted = false; 

    }

    public override void Tick() {

        bool allButtonsPressed = true; 

        foreach(Cube cube in kuvi.cubes) {
            if(kuvi.floor[cube.row, cube.column].type == FloorType.OBJETIVE) {
                cube.colorAnimation(cube.objectiveColor, Cube.MOVE_DURATION);
            }
            else {
                cube.colorAnimation(cube.cubeColor, 0);
                allButtonsPressed = false; 
            }
        }

        if(allButtonsPressed) {

            foreach(Cube cube in kuvi.cubes) {
                cube.completeAnimation();
            }

            levelCompleted = true; 
            
        }

        kuvi.setState(kuvi.moveCubeState);

    }
    
}
