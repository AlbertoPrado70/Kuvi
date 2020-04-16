using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public const float INIT_ANIMATION = 0.25f;
    public const float OUT_ANIMATION = 0.5f;

    public Color floorColor;
    public Color grayFloorColor;
    public Color buttonColor; 

    public MeshFilter floorMesh; 
    public MeshFilter buttonMesh; 

    public Renderer floorRenderer; 
    public MeshFilter floorMeshFilter;
    
    public FloorType type;
    public bool isTweening; 
    public int value; 

    void Awake() {
        type = FloorType.EMPTY;
        isTweening = false;
        value = -1; 
        floorRenderer.material.color = new Color(0, 0, 0, 0);
    }

    public void setFloor(int value) {

        this.value = value; 

        if(value == -1) {
            type = FloorType.EMPTY;
            gameObject.SetActive(false);
        }

        if(value >= 0) {
            type = FloorType.NORMAL;
            gameObject.SetActive(true);
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            floorRenderer.material.color = floorColor;
        }

        if(value == 2) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = buttonColor;
        }
        
    }

    public void initAnimation(float delay) {


        floorRenderer.material.DOFade(0, 0);

        isTweening = true; 

        transform.DOLocalMoveY(2, INIT_ANIMATION).From().SetDelay(delay);      
        floorRenderer.material.DOFade(1, INIT_ANIMATION).SetDelay(delay).OnComplete(() => isTweening = false);  
    
    }

    public void fadeOutAnimation() {
        isTweening = true; 
        floorRenderer.material.DOFade(0, OUT_ANIMATION).OnComplete(() => isTweening = false); 
    }

}
