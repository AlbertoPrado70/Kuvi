using UnityEngine;

public class MoveCube : State {

    // Cubo que desaparece cuando lo tocas
    // Cubo que se mueve al lado contrario

    public enum MoveState{WAITING_TOUCH, MAKE_MOVE};
    public enum Move{NONE, TOP, RIGHT, BOTTOM, LEFT};

    public const int SWIPE_DISTANCE = 30;

    private Kuvi kuvi;

    private Cube touchedCube; 
    private Vector2 touchPosition;
    private Vector2 lastPosition;

    public MoveState state;
    public string levelSolution; 
    public bool autosolve; 

    public MoveCube(Kuvi kuvi) {

        this.kuvi = kuvi; 

        touchPosition = new Vector3();
        lastPosition = new Vector3();
        
        state = MoveState.WAITING_TOUCH;
        levelSolution = ""; 

    }

    public override void Tick() {

        // Registramos la posicion del mouse o evento tactil y determinamos si tocaron un cubo
        if(state == MoveState.WAITING_TOUCH) {

            bool touched = false; 

            if(Input.GetMouseButtonDown(0)) {
                touchPosition = Input.mousePosition;
                touched = true;
            }

            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                touchPosition = Input.GetTouch(0).position;
                touched = true;
            }

            RaycastHit cubeCollider;
            
            if(touched && Physics.Raycast(Camera.main.ScreenPointToRay(touchPosition), out cubeCollider)) {
                touchedCube = cubeCollider.transform.GetComponent<Cube>();
                touchedCube.colorAnimation(touchedCube.lightColor);
                state = MoveState.MAKE_MOVE;
            }

        }

        // Calculamos la distancia entre el punto inicial y la posición obtenida 
        if(state == MoveState.MAKE_MOVE && !kuvi.levelCompleteState.levelCompleted) {

            lastPosition = (Input.touchCount > 0) ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;

            float deltaX = touchPosition.x - lastPosition.x;
            float deltaY = touchPosition.y - lastPosition.y;  

            // Ejecutamos el movimiento
            if(deltaX < -SWIPE_DISTANCE && deltaY < -SWIPE_DISTANCE && !touchedCube.isTweening) {
                state = MoveState.WAITING_TOUCH;
                moveCube(Move.BOTTOM, touchedCube.row, touchedCube.column); 
                kuvi.setState(kuvi.levelCompleteState);
                touchedCube.colorAnimation(touchedCube.actualColor);
            }

            if(deltaX > SWIPE_DISTANCE && deltaY > SWIPE_DISTANCE && !touchedCube.isTweening) {
                state = MoveState.WAITING_TOUCH;
                moveCube(Move.TOP, touchedCube.row, touchedCube.column); 
                kuvi.setState(kuvi.levelCompleteState);
                touchedCube.colorAnimation(touchedCube.actualColor);
            }

            if(deltaX < -SWIPE_DISTANCE && deltaY > SWIPE_DISTANCE && !touchedCube.isTweening) {
                state = MoveState.WAITING_TOUCH;
                moveCube(Move.LEFT, touchedCube.row, touchedCube.column); 
                kuvi.setState(kuvi.levelCompleteState);
                touchedCube.colorAnimation(touchedCube.actualColor);
            }

            if(deltaX > SWIPE_DISTANCE && deltaY < -SWIPE_DISTANCE && !touchedCube.isTweening) {
                state = MoveState.WAITING_TOUCH;
                moveCube(Move.RIGHT, touchedCube.row, touchedCube.column); 
                kuvi.setState(kuvi.levelCompleteState);
                touchedCube.colorAnimation(touchedCube.actualColor);
            }

            // Si no realizaron un movimiento y dejan de enviar eventos regresamos a WAITING_TOUCH
            if(Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
                touchedCube.colorAnimation(touchedCube.actualColor); 
                state = MoveState.WAITING_TOUCH; 
            }

        }

        // Resolvemos
        if(autosolve && kuvi.totalTweens() == 0) {
            Movement m = kuvi.solver.makeMove();
            moveCube(m.move, m.row, m.column);
            kuvi.setState(kuvi.levelCompleteState);
        }

        // Empezamos a resolver
        if(kuvi.menuController.isAutoSolving) {
            autosolve = true; 
            kuvi.setState(kuvi.loadLevelState);
            kuvi.menuController.isAutoSolving = false;
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
        levelSolution += m + row + column + ";"; 

        // Movimiento
        if(move == Move.TOP) {
            for(int i = row - 1; i >= 0; i--) {
                int nextValue = kuvi.level.matrix[i * Kuvi.LEVEL_SIZE + column];
                cubeCollided = (nextValue == -1 || nextValue == 1 || nextValue == 3 || nextValue == 5 || nextValue == 7) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.RIGHT) {
            for(int i = column + 1; i < Kuvi.LEVEL_SIZE; i++) {
                int nextValue = kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + i];
                cubeCollided = (nextValue == -1 || nextValue == 1 || nextValue == 3 || nextValue == 5 || nextValue == 7) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.BOTTOM) {
            for(int i = row + 1; i < Kuvi.LEVEL_SIZE; i++) {
                int nextValue = kuvi.level.matrix[i * Kuvi.LEVEL_SIZE + column];
                cubeCollided = (nextValue == -1 || nextValue == 1 || nextValue == 3 || nextValue == 5 || nextValue == 7) ? true : cubeCollided;
                distance += (!cubeCollided) ? 1 : 0;
            }
        }

        if(move == Move.LEFT) {
            for(int i = column - 1; i >= 0; i--) {
                int nextValue = kuvi.level.matrix[row * Kuvi.LEVEL_SIZE + i];
                cubeCollided = (nextValue == -1 || nextValue == 1 || nextValue == 3 || nextValue == 5 || nextValue == 7) ? true : cubeCollided;
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
