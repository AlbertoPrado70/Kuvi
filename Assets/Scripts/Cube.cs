using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    public int row; 
    public int column; 

    public void setPosition(int row, int column) {
        this.row = row; 
        this.column = column; 
    }

    public void moveRight(int distance) {
        transform.DOMoveZ(transform.position.z + distance, 0.25f).SetEase(Ease.InOutQuad);
    }

}
