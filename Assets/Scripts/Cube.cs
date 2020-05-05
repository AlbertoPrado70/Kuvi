using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour {
    
    // Cubo imitador: Realiza el mismo movimiento que el usuario
    // Cubo contrario: hace lo contrario al usuario
    // Cubo bomba: Explota cubos rotos
    // Cubo roto: Se destruyo cuando le explota una bomba

    public const float INIT_DURATION = 0.5f; 
    public const float OUT_ANIMATION = 0.5f;
    public const float MOVE_DURATION = 0.6f;
    public const float SELECTED_DURATION = 0.2f;

    public Color blueCube; 
    public Color yellowCube;
    public Color redCube; 
    public Color grayCube;

    public Renderer cubeRenderer;
    public Renderer effectRenderer;
    public Transform effectTransform;
    public AudioSource slideEffect;

    public int row; 
    public int column; 
    public CubeColor cubeColor; 

    public bool isTweening; 

    void Awake() {
        isTweening = false; 
    }

    public void set(int row, int column, int value) {

        this.row = row; 
        this.column = column; 

        if(value == 1) {
            cubeRenderer.material.color = blueCube; 
            cubeColor = CubeColor.BLUE;
        }

        if(value == 3) {
            cubeRenderer.material.color = yellowCube;
            cubeColor = CubeColor.YELLOW;
        }

        if(value == 5) {
            cubeRenderer.material.color = redCube;
            cubeColor = CubeColor.RED; 
        }

        if(value == 7) {
            cubeRenderer.material.color = grayCube;
            cubeColor = CubeColor.NONE;
        }
        
    }

    public void initAnimation(float delay) {
        isTweening = true; 
        cubeRenderer.material.DOFade(0, INIT_DURATION).From().SetDelay(delay).OnComplete(() => isTweening = false);
    }

    public void move(MoveCube.Move move, int distance) {

        isTweening = true;
        float floorLength = cubeRenderer.bounds.size.x;
        slideEffect.Play();

        if(move == MoveCube.Move.TOP) { 
            transform.DOMoveX(transform.position.x - (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutQuart).OnComplete(() => isTweening = false);
        }

        if(move == MoveCube.Move.RIGHT) {
            transform.DOMoveZ(transform.position.z + (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutQuart).OnComplete(() => isTweening = false);
        }

        if(move == MoveCube.Move.BOTTOM) {
            transform.DOMoveX(transform.position.x + (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutQuart).OnComplete(() => isTweening = false);
        }

        if(move == MoveCube.Move.LEFT) {
            transform.DOMoveZ(transform.position.z - (distance * floorLength), MOVE_DURATION).SetEase(Ease.InOutQuart).OnComplete(() => isTweening = false);
        }

    }

    // public void colorAnimation(Color color) {
    //     cubeRenderer.material.DOColor(color, 0.1f);
    // }

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


}