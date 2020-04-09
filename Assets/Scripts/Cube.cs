using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    public const float INIT_DURATION = 0.5f; 
    public const float OUT_ANIMATION = 0.5f;
    public const float MOVE_DURATION = 0.5f;
    public const float SELECTED_DURATION = 0.2f;

    public Color cubeColor; 
    public Color objectiveColor; 
    public Color selectedColor; 
    public Renderer cubeRenderer;

    public Renderer effectRenderer;
    public Transform effectTransform;

    public int row; 
    public int column; 

    public bool readyToMove; 

    void Start() {

        readyToMove = false; 

    }

    public void setPosition(int row, int column) {

        this.row = row; 
        this.column = column; 

    }

    public void initAnimation(float delay) {

        cubeRenderer.material.color = cubeColor;
        cubeRenderer.material.DOFade(0, INIT_DURATION).From().SetDelay(delay).OnComplete(() => readyToMove = true);

    }

    public void move(MoveCube.Move move, int distance) {

        if(move == MoveCube.Move.TOP) {
            readyToMove = false; 
            transform.DOMoveX(transform.position.x - (distance * cubeRenderer.bounds.size.x), MOVE_DURATION).SetEase(Ease.InOutQuad).OnComplete(() => readyToMove = true);
        }

        if(move == MoveCube.Move.RIGHT) {
            readyToMove = false; 
            transform.DOMoveZ(transform.position.z + (distance * cubeRenderer.bounds.size.x), MOVE_DURATION).SetEase(Ease.InOutQuad).OnComplete(() => readyToMove = true);
        }

        if(move == MoveCube.Move.BOTTOM) {
            readyToMove = false; 
            transform.DOMoveX(transform.position.x + (distance * cubeRenderer.bounds.size.x), MOVE_DURATION).SetEase(Ease.InOutQuad).OnComplete(() => readyToMove = true);
        }

        if(move == MoveCube.Move.LEFT) {
            readyToMove = false; 
            transform.DOMoveZ(transform.position.z - (distance * cubeRenderer.bounds.size.x), MOVE_DURATION).SetEase(Ease.InOutQuad).OnComplete(() => readyToMove = true);
        }

    }

    public void colorAnimation(Color color, float delay) {

        cubeRenderer.material.DOColor(color, 1f).SetDelay(delay);

    }

    public void completeAnimation() {

        readyToMove = false; 

        effectRenderer.material.DOFade(1, 0);
        effectTransform.DOScale(0, 0);

        effectRenderer.material.DOFade(0, 0.7f).SetDelay(MOVE_DURATION).OnComplete(() => readyToMove = true);
        effectTransform.DOScale(5, 0.7f).SetDelay(MOVE_DURATION);

    }


    public void fadeOutAnimation() {

        cubeRenderer.material.DOFade(0, OUT_ANIMATION); 

    }

}
