using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    public int row; 
    public int column; 

    public void setPosition(int row, int column) {
        this.row = row; 
        this.column = column; 
    }

    public void move(Iddle.Move move, int distance) {

        if(move == Iddle.Move.TOP) {
            transform.DOMoveX(transform.position.x - distance, 0.5f).SetEase(Ease.InOutQuad);
        }

        if(move == Iddle.Move.RIGHT) {
            transform.DOMoveZ(transform.position.z + distance, 0.5f).SetEase(Ease.InOutQuad);
        }

        if(move == Iddle.Move.BOTTOM) {
            transform.DOMoveX(transform.position.x + distance, 0.5f).SetEase(Ease.InOutQuad);
        }

        if(move == Iddle.Move.LEFT) {
            transform.DOMoveZ(transform.position.z - distance, 0.5f).SetEase(Ease.InOutQuad);
        }

    }

}
