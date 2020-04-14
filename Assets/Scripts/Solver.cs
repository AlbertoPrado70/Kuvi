using UnityEngine;

public class Solver {
    
    public string[] solution = new string[6]{
        "b03;",
        "b02;t64",
        "b03;r30;",
        "b01;t63;b05;",
        "t43;t53;r13;t63;l13;",
        "b00;b06;l66;t60;r00;b06;l66;l61;t60;r00;b06;l66;l62;",
    };

    public string[] currentSolution; 
    public int currentMove; 

    public Solver() { 
        currentMove = 0; 
    }

    public void parseSolution(int level) {
        level = (level > solution.Length - 1) ? 0 : level; 
        currentSolution = solution[level].Split(';');
        currentMove = 0; 
    }

    public Movement makeMove() {

        Movement movement = new Movement();

        movement.move = MoveCube.Move.NONE; 

        movement.move = (currentSolution[currentMove][0] == 't') ? MoveCube.Move.TOP : movement.move;
        movement.move = (currentSolution[currentMove][0] == 'r') ? MoveCube.Move.RIGHT : movement.move;
        movement.move = (currentSolution[currentMove][0] == 'b') ? MoveCube.Move.BOTTOM : movement.move;
        movement.move = (currentSolution[currentMove][0] == 'l') ? MoveCube.Move.LEFT : movement.move; 


        Debug.Log(currentSolution[currentMove][0]);
        
        int row = (int) char.GetNumericValue(currentSolution[currentMove][1]);
        int column = (int) char.GetNumericValue(currentSolution[currentMove][2]);

        movement.row = row; 
        movement.column = column; 
        currentMove++; 

        return(movement); 

    }

}


