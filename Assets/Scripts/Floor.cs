using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public const float INIT_ANIMATION = 1f;

    public MeshFilter floorMesh; 
    public MeshFilter objectiveMesh; 
    public MeshFilter platFormMesh; 
    public MeshFilter buttonMesh; 

    public Renderer floorRenderer; 
    public MeshFilter floorMeshFilter;
    public FloorType type;

    public void setFloor(int value) {

        if(value == -1) {
            type = FloorType.EMPTY;
            gameObject.SetActive(false);
        }

        if(value >= 0) {
            type = FloorType.NORMAL;
            gameObject.SetActive(true);
            floorMeshFilter.mesh = floorMesh.sharedMesh;
        }

        if(value == 2) {
            type = FloorType.OBJETIVE;
            floorMeshFilter.mesh = objectiveMesh.sharedMesh;
        }

        if(value == 3) {
            type = FloorType.BUTTON;
            floorMeshFilter.mesh = buttonMesh.sharedMesh;
        }

        if(value == 4) {
            type = FloorType.INACTIVE;
            floorMeshFilter.mesh = platFormMesh.sharedMesh;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        }

        if(value == 5) {
            type = FloorType.ACTIVE;
            floorMeshFilter.mesh = platFormMesh.sharedMesh;
        }
        
    }

    public void initAnimation(float delay) {

        transform.DOMoveY(0, INIT_ANIMATION).From().SetDelay(delay);      
        floorRenderer.material.DOFade(0, INIT_ANIMATION).From().SetDelay(delay);  
    
    }

}
