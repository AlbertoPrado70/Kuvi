using DG.Tweening;

public class ActivateFloor : State {

    private Kuvi kuvi; 
    public bool isFloorActive;

    public ActivateFloor(Kuvi kuvi) {

        this.kuvi = kuvi; 
        isFloorActive = false;

    }

    public override void Tick() {

        // if(!isFloorActive) {
        //     foreach(Cube cube in kuvi.cubes) {
        //         if(kuvi.floor[cube.row, cube.column].type == FloorType.BUTTON) {
        //             activateLevelFloor();
        //         }
        //     }
        // }

        // if(isFloorActive) {

        //     bool cubeInButton = false; 

        //     foreach(Cube cube in kuvi.cubes) {
        //         if(kuvi.floor[cube.row, cube.column].type == FloorType.BUTTON) {
        //             cubeInButton = true; 
        //         }
        //     }

        //     if(!cubeInButton) {
        //         desactivateLevelFloor();
        //     }

        // }

        kuvi.setState(kuvi.levelCompleteState);

    }

    // public void activateLevelFloor() {

    //     for(int row = 0; row < Kuvi.LEVEL_SIZE; row++) {
    //         for(int column = 0; column < Kuvi.LEVEL_SIZE; column++) {
    //             if(kuvi.floor[row, column].type == FloorType.INACTIVE) {
    //                 kuvi.floor[row, column].type = FloorType.ACTIVE;
    //                 kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] = 5; 
    //                 kuvi.floor[row, column].transform.DOLocalMoveY(0, 0.5f).SetDelay(0.5f);
    //             }
    //         }
    //     }

        
    //     isFloorActive = true; 

    // }

    // public void desactivateLevelFloor() {

    //     for(int row = 0; row < Kuvi.LEVEL_SIZE; row++) {
    //         for(int column = 0; column < Kuvi.LEVEL_SIZE; column++) {
    //             if(kuvi.floor[row, column].type == FloorType.ACTIVE) {
    //                 kuvi.floor[row, column].type = FloorType.INACTIVE;
    //                 kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] = 4; 
    //                 kuvi.floor[row, column].transform.DOLocalMoveY(-0.8f, 0.5f);
    //             }
    //         }
    //     }

        
    //     isFloorActive = false; 

    // }

}