using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    public int row; 
    public int column; 

    public void initAnimation() {

        GetComponent<Renderer>().material.DOFade(0, 0.5f).From().SetDelay(2);

    }

    public void setPosition(int row, int column) {
        this.row = row; 
        this.column = column; 
    }

    public void move(MoveCube.Move move, int distance) {

        if(move == MoveCube.Move.TOP) {
            transform.DOMoveX(transform.position.x - distance, 0.5f).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.RIGHT) {
            transform.DOMoveZ(transform.position.z + distance, 0.5f).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.BOTTOM) {
            transform.DOMoveX(transform.position.x + distance, 0.5f).SetEase(Ease.InOutQuad);
        }

        if(move == MoveCube.Move.LEFT) {
            transform.DOMoveZ(transform.position.z - distance, 0.5f).SetEase(Ease.InOutQuad);
        }

    }

}
