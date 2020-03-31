using UnityEngine;

public class Iddle : State {

    public enum Move{TOP, RIGHT, BOTTOM, LEFT};

    private Checkboard checkboard;

    public Iddle(Checkboard checkboard) {

        this.checkboard = checkboard; 

    }

    public override void Tick() {

        if(Input.GetKeyDown("s")) {
            moveCube(Move.BOTTOM, 0, 1);
        }

        if(Input.GetKeyDown("w")) {
            moveCube(Move.TOP, 0, 1);
        }

        if(Input.GetKeyDown("d")) {
            moveCube(Move.RIGHT, 0, 1);
        }

        if(Input.GetKeyDown("a")) {
            moveCube(Move.LEFT, 0, 1);
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
