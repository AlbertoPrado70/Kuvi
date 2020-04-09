﻿using UnityEngine;
using DG.Tweening;

public class MoveCube : State {

    public enum Move{TOP, RIGHT, BOTTOM, LEFT};
    public const int SWIPE_DISTANCE = 30;

    private Kuvi kuvi;

    private bool isTouched; 
    private Vector3 touchPosition;
    private Vector3 lastPosition;


    public MoveCube(Kuvi kuvi) {

        this.kuvi = kuvi; 

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

        if(isTouched && !kuvi.levelCompleteState.levelCompleted) {

            lastPosition = (Input.touchCount > 0) ? (Vector3)Input.GetTouch(0).position : (Vector3)Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            
            if (Physics.Raycast(ray, out hit)) {

                Cube cube = hit.transform.GetComponent<Cube>();

                if(touchPosition.x - lastPosition.x < -SWIPE_DISTANCE && touchPosition.y - lastPosition.y < -SWIPE_DISTANCE && cube.readyToMove) {
                    moveCube(Move.BOTTOM, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.activateFloorState);
                }

                if(touchPosition.x - lastPosition.x > SWIPE_DISTANCE && touchPosition.y - lastPosition.y > SWIPE_DISTANCE && cube.readyToMove) {
                    moveCube(Move.TOP, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.activateFloorState);
                }

                if(touchPosition.x - lastPosition.x < -SWIPE_DISTANCE && touchPosition.y - lastPosition.y > SWIPE_DISTANCE && cube.readyToMove) {
                    moveCube(Move.LEFT, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.activateFloorState);
                }

                if(touchPosition.x - lastPosition.x > SWIPE_DISTANCE && touchPosition.y - lastPosition.y < -SWIPE_DISTANCE && cube.readyToMove) {
                    moveCube(Move.RIGHT, cube.row, cube.column);
                    isTouched = false;
                    kuvi.setState(kuvi.activateFloorState);
                }

            }

        }

        // Nivel completado. Limpiamos el estado del juego y pasamos al siguiente nivel 
        if(isTouched && kuvi.levelCompleteState.levelCompleted && cubesPlayingAnimation() == 0) {

            foreach(Cube cube in kuvi.cubes) {
                cube.DOComplete();
                cube.effectRenderer.DOComplete();
                cube.effectTransform.DOComplete();
            }

            kuvi.menuController.levelMessage.DOComplete();
            kuvi.menuController.completeAnimation();

            kuvi.levelCompleteState.levelCompleted = false; 
            kuvi.actualLevel++;

            kuvi.setState(kuvi.loadLevelState);

            isTouched = false;

        }

    }

    public int cubesPlayingAnimation() {

        int totalPlayingAnimations = 0; 

        foreach(Cube cube in kuvi.cubes) {
            totalPlayingAnimations += (!cube.readyToMove) ? 1 : 0;
        }

        return(totalPlayingAnimations);

    }

    public void moveCube(Move move, int row, int column) {

        int distance = 0; 
        bool cubeCollided = false;

        // Desactivamos pisos antes de mover

        if(move == Move.RIGHT && column + 1 < Kuvi.LEVEL_SIZE && kuvi.floor[row, column].type == FloorType.BUTTON) {
            if(kuvi.floor[row, column + 1].type == FloorType.NORMAL || kuvi.floor[row, column + 1].type == FloorType.BUTTON || kuvi.floor[row, column + 1].type == FloorType.OBJETIVE) {
                kuvi.activateFloorState.desactivateLevelFloor();
            }
        }

        if(move == Move.LEFT && column - 1 >= 0 && kuvi.floor[row, column].type == FloorType.BUTTON) {
            if(kuvi.floor[row, column - 1].type == FloorType.NORMAL || kuvi.floor[row, column - 1].type == FloorType.BUTTON || kuvi.floor[row, column - 1].type == FloorType.OBJETIVE) {
                kuvi.activateFloorState.desactivateLevelFloor();
            }
        }

        if(move == Move.TOP && row - 1 < Kuvi.LEVEL_SIZE && kuvi.floor[row, column].type == FloorType.BUTTON) {
            if(kuvi.floor[row - 1, column].type == FloorType.NORMAL || kuvi.floor[row - 1, column].type == FloorType.BUTTON || kuvi.floor[row - 1, column].type == FloorType.OBJETIVE) {
                kuvi.activateFloorState.desactivateLevelFloor();
            }
        }

        if(move == Move.BOTTOM && row + 1 < Kuvi.LEVEL_SIZE && kuvi.floor[row, column].type == FloorType.BUTTON) {
            if(kuvi.floor[row + 1, column].type == FloorType.NORMAL || kuvi.floor[row + 1, column].type == FloorType.BUTTON || kuvi.floor[row + 1, column].type == FloorType.OBJETIVE) {
                kuvi.activateFloorState.desactivateLevelFloor();
            }
        }

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
