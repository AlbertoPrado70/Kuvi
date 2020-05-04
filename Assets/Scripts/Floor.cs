using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public const float INIT_ANIMATION = 0.25f;
    public const float OUT_ANIMATION = 0.5f;

    public Color floorColor;
    public Color grayFloorColor;

    public Color redButtonColor;
    public Color yellowButtonColor;
    public Color blueButtonColor;

    public MeshFilter floorMesh; 
    public MeshFilter buttonMesh; 

    public Renderer floorRenderer; 
    public MeshFilter floorMeshFilter;
    
    public FloorType type;
    public CubeColor cubeColor; 
    public bool isTweening; 
    public int value; 


    void Awake() {
        type = FloorType.EMPTY;
        isTweening = false;
        value = -1; 
        floorRenderer.material.color = new Color(0, 0, 0, 0);
    }

    public void setFloor(int value) {

        this.cubeColor = CubeColor.NONE;
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

        // Objetivo azul
        if(value == 2) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = blueButtonColor;
            cubeColor = CubeColor.BLUE;
        }

        // Objetivo amarillo
        if(value == 4) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = yellowButtonColor;
            cubeColor = CubeColor.YELLOW;
        }

        // Objetivo rojo
        if(value == 6) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = redButtonColor;
            cubeColor = CubeColor.RED;
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