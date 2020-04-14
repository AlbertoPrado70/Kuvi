using UnityEngine;

public class MoveCube : State {

    public enum Move{NONE, TOP, RIGHT, BOTTOM, LEFT};
    public const int SWIPE_DISTANCE = 20;

    private Kuvi kuvi;

    private Vector3 touchPosition;
    private Vector3 lastPosition;

    public bool isTouched; 
    public bool autosolve; 

    // String para ayudarnos a escribir soluciones
    public string solucion; 

    public MoveCube(Kuvi kuvi) {

        this.kuvi = kuvi; 

        touchPosition = new Vector3();
        lastPosition = new Vector3();

        isTouched = false; 
        autosolve = false; 

    }

    public override void Tick() {

        // Registramos un toque de pantalla o de mouse 
        if(Input.GetMouseButtonDown(0)) {
            touchPosition = Input.mousePosition;
            isTouched = true;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            touchPosition = Input.GetTouch(0).position;
            isTouched = true;
        }

        if(isTouched && !kuvi.levelCompleteState.levelCompleted && !autosolve) {

            lastPosition = (Input.touchCount > 0) ? (Vector3)Input.GetTouch(0).position : (Vector3)Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            
            if (Physics.Raycast(ray, out hit)) {

                Cube cube = hit.transform.GetComponent<Cube>();

                if(touchPosition.x - lastPosition.x < -SWIPE_DISTANCE && touchPosition.y - lastPosition.y < -SWIPE_DISTANCE && !cube.isTweening) {
                    moveCube(Move.BOTTOM, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.levelCompleteState);
                }

                if(touchPosition.x - lastPosition.x > SWIPE_DISTANCE && touchPosition.y - lastPosition.y > SWIPE_DISTANCE && !cube.isTweening) {
                    moveCube(Move.TOP, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.levelCompleteState);
                }

                if(touchPosition.x - lastPosition.x < -SWIPE_DISTANCE && touchPosition.y - lastPosition.y > SWIPE_DISTANCE && !cube.isTweening) {
                    moveCube(Move.LEFT, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.levelCompleteState);
                }

                if(touchPosition.x - lastPosition.x > SWIPE_DISTANCE && touchPosition.y - lastPosition.y < -SWIPE_DISTANCE && !cube.isTweening) {
                    moveCube(Move.RIGHT, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.levelCompleteState);
                }

            }

        }

        // Cambiamos de nivel
        if(kuvi.menuController.lastLevel) {
            kuvi.menuController.lastLevel = false; 
            kuvi.setState(kuvi.loadLevelState);
        }

        if(kuvi.menuController.nextLevel) {
            kuvi.menuController.nextLevel = false;
            kuvi.setState(kuvi.loadLevelState);
        }

        if(autosolve && kuvi.totalTweens() == 0) {
            Movement m = kuvi.solver.makeMove();
            moveCube(m.move, m.row, m.column);
            kuvi.setState(kuvi.levelCompleteState);
        }

        // Empezamos a resolver
        if(Input.GetKeyDown("a")) {
            autosolve = true; 
            kuvi.setState(kuvi.loadLevelState);
        }

        // Reiniciamos el nivel 
        if(Input.GetKeyDown("r")) {
            kuvi.setState(kuvi.loadLevelState);
        }

    }

    public void moveCube(Move move, int row, int column) {

        int distance = 0; 
        bool cubeCollided = false;

        // Moving Debug
        string m = ""; 
        m = (move == Move.TOP) ? "t" : m; 
        m = (move == Move.RIGHT) ? "r" : m; 
        m = (move == Move.BOTTOM) ? "b" : m; 
        m = (move == Move.LEFT) ? "l" : m;
        solucion += m + row + column + ";"; 

        // Movimiento

        if(move == Move.TOP) {
            for(int i = row - 1; i >= 0; i--) {
                int nextValue = kuvi.level.matrix[i * Kuvi.LEVEL_SIZE + column];
                cubeCollided = (nextValue == 1 || nextValue == -1 || nextValue == 4) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.RIGHT) {
            for(int i = column + 1; i < Kuvi.LEVEL_SIZE; i++) {
                int nextValue = kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + i];
                cubeCollided = (nextValue == 1 || nextValue == -1 || nextValue == 4) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.BOTTOM) {
            for(int i = row + 1; i < Kuvi.LEVEL_SIZE; i++) {
                int nextValue = kuvi.level.matrix[i * Kuvi.LEVEL_SIZE + column];
                cubeCollided = (nextValue == 1 || nextValue == -1 || nextValue == 4) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.LEFT) {
            for(int i = column - 1; i >= 0; i--) {
                int nextValue = kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + i];
                cubeCollided = (nextValue == 1 || nextValue == -1 || nextValue == 4) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        foreach(Cube cube in kuvi.cubes) {
            if(cube.row == row && cube.column == column && distance > 0) {

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
                
                kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + column] = 0;
                kuvi.level.matrix[cube.row * Kuvi.LEVEL_SIZE + cube.column] = 1;

            }
        }

    }

}
