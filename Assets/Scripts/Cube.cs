using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    // Cubo imitador: Realiza el mismo movimiento que el usuario
    // Cubo contrario: hace lo contrario al usuario
    // Cubo bomba: Explota cubos rotos
    // Cubo roto: Se destruyo cuando le explota una bomba

    public const float INIT_DURATION = 0.5f; 
    public const float OUT_ANIMATION = 0.5f;
    public const float MOVE_DURATION = 0.5f;
    public const float SELECTED_DURATION = 0.2f;

    public Color cubeColor; 
    public Color objectiveColor; 
    public Renderer cubeRenderer;

    public Renderer effectRenderer;
    public Transform effectTransform;

    public int row; 
    public int column; 

    public bool isTweening; 

    void Awake() {
        isTweening = false; 
    }

    public void setPosition(int row, int column) {
        this.row = row; 
        this.column = column; 
    }

    public void initAnimation(float delay) {
        isTweening = true; 
        cubeRenderer.material.color = cubeColor;
        cubeRenderer.material.DOFade(0, INIT_DURATION).From().SetDelay(delay).OnComplete(() => isTweening = false);
    }

    public void move(MoveCube.Move move, int distance) {

        isTweening = true;
        float floorLength = cubeRenderer.bounds.size.x;

        if(move == MoveCube.Move.TOP) { 
            transform.DOMoveX(transform.position.x - (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutCubic).OnComplete(() => isTweening = false);
        }

        if(move == MoveCube.Move.RIGHT) {
            transform.DOMoveZ(transform.position.z + (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutCubic).OnComplete(() => isTweening = false);
        }

        if(move == MoveCube.Move.BOTTOM) {
            transform.DOMoveX(transform.position.x + (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutCubic).OnComplete(() => isTweening = false);
        }

        if(move == MoveCube.Move.LEFT) {
            transform.DOMoveZ(transform.position.z - (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutCubic).OnComplete(() => isTweening = false);
        }

    }

    public void colorAnimation(Color color) {
        cubeRenderer.material.DOColor(color, 1f);
    }

    public void completeAnimation() {

        isTweening = true; 

        effectRenderer.material.DOFade(1, 0);
        effectTransform.DOScale(0, 0);

        cubeRenderer.material.DOFade(0, 0.7f);
        effectRenderer.material.DOFade(0, 0.7f);
        effectTransform.DOScale(5, 0.7f).OnComplete(() => isTweening = false);

    }


    public void fadeOutAnimation() {
        isTweening = true;
        cubeRenderer.material.DOFade(0, OUT_ANIMATION).OnComplete(() => isTweening = false); 
    }

    // TODO: Creo que esta función no funciona muy bien.
    public void completeAllAnimations() {
        transform.DOComplete();
        cubeRenderer.DOComplete();
        effectRenderer.DOComplete();
        effectTransform.DOComplete();
        isTweening = false; 
    }

}
