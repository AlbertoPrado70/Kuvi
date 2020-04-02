using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    public const float INIT_DURATION = 0.5f; 
    public const float MOVE_DURATION = 0.5f;

    public Renderer cubeRenderer; 
    public Color cubeColor; 

    public int row; 
    public int column; 

    public void setPosition(int row, int column) {
        this.row = row; 
        this.column = column; 
    }

    public void initAnimation() {

        cubeRenderer.material.color = cubeColor;
        cubeRenderer.material.DOFade(0, INIT_DURATION).From().SetDelay(2);

    }

    public void move(MoveCube.Move move, int distance) {

        if(move == MoveCube.Move.TOP) {
            transform.DOMoveX(transform.position.x - distance, MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.RIGHT) {
            transform.DOMoveZ(transform.position.z + distance, MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.BOTTOM) {
            transform.DOMoveX(transform.position.x + distance, MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.LEFT) {
            transform.DOMoveZ(transform.position.z - distance, MOVE_DURATION).SetEase(Ease.InOutQuad);
        }

    }

}
