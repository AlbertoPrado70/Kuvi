using UnityEngine;

public class MoveCube : State {

    public enum Move{TOP, RIGHT, BOTTOM, LEFT};
    public const int SWIPE_DISTANCE = 50;

    private Checkboard checkboard;

    private bool isTouched; 
    private Vector3 touchPosition;
    private Vector3 lastPosition;


    public MoveCube(Checkboard checkboard) {

        this.checkboard = checkboard; 

        isTouched = false;
        touchPosition = new Vector3(0, 0, 0);

    }

    public override void Tick() {

        if(Input.GetMouseButtonDown(0)) {
            touchPosition = Input.mousePosition;
            isTouched = true;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            touchPosition = Input.GetTouch(0).position;
            isTouched = true;
        }

        if(isTouched) {

            lastPosition = (Input.touchCount > 0) ? (Vector3)Input.GetTouch(0).position : (Vector3)Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            
            if (Physics.Raycast(ray, out hit)) {

                Cube cube = hit.transform.GetComponent<Cube>();

                if(touchPosition.x - lastPosition.x < -SWIPE_DISTANCE && touchPosition.y - lastPosition.y < -SWIPE_DISTANCE) {
                    moveCube(Move.RIGHT, cube.row, cube.column);
                    isTouched = false;
                }

                if(touchPosition.x - lastPosition.x > SWIPE_DISTANCE && touchPosition.y - lastPosition.y > SWIPE_DISTANCE) {
                    moveCube(Move.LEFT, cube.row, cube.column);
                    isTouched = false;
                }

                if(touchPosition.x - lastPosition.x < -SWIPE_DISTANCE && touchPosition.y - lastPosition.y > SWIPE_DISTANCE) {
                    moveCube(Move.BOTTOM, cube.row, cube.column);
                    isTouched = false;
                }

                if(touchPosition.x - lastPosition.x > SWIPE_DISTANCE && touchPosition.y - lastPosition.y < -SWIPE_DISTANCE) {
                    moveCube(Move.TOP, cube.row, cube.column);
                    isTouched = false;
                }

            }

        }

    }

     public void moveCube(Move move, int row, int column) {

        int distance = 0; 
        bool cubeCollided = false;

        if(move == Move.TOP) {
            for(int i = row - 1; i >= 0; i--) {
                int nextValue = checkboard.level.matrix[i * Checkboard.LEVEL_SIZE + column];
                cubeCollided = (nextValue == 1 || nextValue == -1) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.RIGHT) {
            for(int i = column + 1; i < Checkboard.LEVEL_SIZE; i++) {
                int nextValue = checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + i];
                cubeCollided = (nextValue == 1 || nextValue == -1) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.BOTTOM) {
            for(int i = row + 1; i < Checkboard.LEVEL_SIZE; i++) {
                int nextValue = checkboard.level.matrix[i * Checkboard.LEVEL_SIZE + column];
                cubeCollided = (nextValue == 1 || nextValue == -1) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.LEFT) {
            for(int i = column - 1; i >= 0; i--) {
                int nextValue = checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + i];
                cubeCollided = (nextValue == 1 || nextValue == -1) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        foreach(Cube cube in checkboard.cubes) {
            if(cube.row == row && cube.column == column) {

                cube.move(move, distance);

                if(move == Move.TOP) {
                    cube.row = cube.row - distance;
                }

                if(move == Move.RIGHT) {
                    cube.column = cube.column + distance;
                }

                if(move == Move.BOTTOM) {
                    cube.row = cube.row + distance;
                }

                if(move == Move.LEFT) {
                    cube.column = cube.column - distance;
                }
                
                checkboard.level.matrix[row * Checkboard.LEVEL_SIZE + column] = 0;
                checkboard.level.matrix[cube.row * Checkboard.LEVEL_SIZE + cube.column] = 1;

            }
        }

    }

}
