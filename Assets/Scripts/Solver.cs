using UnityEngine;

public class Solver {
    
    public int[,] solution = new int[4, 9] {
        {3, 0, 3, -1, -1, -1, -1, -1, -1},
        {3, 0, 2, 1, 6, 4, -1, -1, -1},
        {3, 0, 3, 2, 3, 0, -1, -1, -1},
        {3, 0, 1, 1, 6, 3, 3, 0, 5},
    };

    public int currentSolution; 
    public int currentMove; 

    public Solver() {
        currentSolution = 0; 
        currentMove = 0; 
    }

    public void makeMove(MoveCube moveCubeState) {

        MoveCube.Move move = MoveCube.Move.BOTTOM; 

        if(solution[currentSolution, currentMove] == 1) {
            move = MoveCube.Move.TOP; 
        }

        if(solution[currentSolution, currentMove] == 2) {
            move = MoveCube.Move.RIGHT; 
        }

        if(solution[currentSolution, currentMove] == 3) {
            move = MoveCube.Move.BOTTOM; 
        }

        if(solution[currentSolution, currentMove] == 4) {
            move = MoveCube.Move.LEFT; 
        }

        if(solution[currentSolution, currentMove + 1] != -1 && solution[currentSolution, currentMove + 2] != -1)
            moveCubeState.moveCube(move, solution[currentSolution, currentMove + 1], solution[currentSolution, currentMove + 2]);

    }

}
