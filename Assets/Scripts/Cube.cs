using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    public const float INIT_DURATION = 0.5f; 
    public const float MOVE_DURATION = 0.5f;

    public Color cubeColor; 
    public Color objectiveColor; 
    public Color buttonColor; 
    public Renderer cubeRenderer; 

    public int row; 
    public int column; 

    public void setPosition(int row, int column) {
        this.row = row; 
        this.column = column; 
    }

    public void initAnimation(float delay) {

        cubeRenderer.material.color = cubeColor;
        cubeRenderer.material.DOFade(0, INIT_DURATION).From().SetDelay(delay);

    }

    public void move(MoveCube.Move move, int distance) {

        if(move == MoveCube.Move.TOP) {
            transform.DOMoveX(transform.position.x - (distance * 0.8f), MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.RIGHT) {
            transform.DOMoveZ(transform.position.z + (distance * 0.8f), MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.BOTTOM) {
            transform.DOMoveX(transform.position.x + (distance * 0.8f), MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.LEFT) {
            transform.DOMoveZ(transform.position.z - (distance * 0.8f), MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

    }

}
