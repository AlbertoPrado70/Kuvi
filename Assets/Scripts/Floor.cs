using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public const float INIT_ANIMATION = 0.6f;
    public const float OUT_ANIMATION = 0.5f;

    public Color floorColor;
    public Color objectiveColor; 
    public Color buttonColor;

    public MeshFilter floorMesh; 
    public MeshFilter buttonMesh; 

    public Renderer floorRenderer; 
    public MeshFilter floorMeshFilter;
    public FloorType type;

    public Vector3 firstPosition; 

    void Start() {

        firstPosition = transform.position;

    }

    public void setFloor(int value) {

        if(value == -1) {
            type = FloorType.EMPTY;
            gameObject.SetActive(false);
        }

        if(value >= 0) {
            type = FloorType.NORMAL;
            gameObject.SetActive(true);
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            floorRenderer.material.color = floorColor;
            transform.position = firstPosition; 
        }

        if(value == 2) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = objectiveColor;
        }

        if(value == 3) {
            type = FloorType.BUTTON;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
            floorRenderer.material.color = buttonColor;
        }

        if(value == 4) {
            type = FloorType.INACTIVE;
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            floorRenderer.material.color = buttonColor;
        }

        if(value == 5) {
            type = FloorType.ACTIVE;
            floorMeshFilter.mesh = floorMesh.sharedMesh;
            floorRenderer.material.color = buttonColor;
        }
        
    }

    public void initAnimation(float delay) {

        floorRenderer.material.DOFade(0, 0);

        transform.DOLocalMoveY(5, INIT_ANIMATION).From().SetDelay(delay);      
        floorRenderer.material.DOFade(0, INIT_ANIMATION).From().SetDelay(delay);  
    
    }

    public void fadeOutAnimation() {

        floorRenderer.material.DOFade(0, OUT_ANIMATION); 

    }

    public void completeAllAnimations() {
        floorRenderer.DOComplete();
    }

}
