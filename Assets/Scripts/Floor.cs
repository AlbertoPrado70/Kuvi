using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    public const float INIT_ANIMATION = 1f;

    public Color floorColor; 
    public Color objectiveColor; 
    public Color buttonColor; 
    public Color movingFloor; 

    public Renderer floorRenderer; 
    public FloorType type;

    public void setFloor(int value) {

        if(value == -1) {
            type = FloorType.EMPTY;
            gameObject.SetActive(false);
        }

        if(value >= 0) {
            type = FloorType.NORMAL;
            gameObject.SetActive(true);
            floorRenderer.material.color = floorColor; 
        }

        if(value == 2) {
            type = FloorType.OBJETIVE;
            floorRenderer.material.color = objectiveColor;
        }

        if(value == 3) {
            type = FloorType.BUTTON;
            floorRenderer.material.color = buttonColor;
        }

        if(value == 4) {
            type = FloorType.INACTIVE;
            floorRenderer.material.color = movingFloor;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
        }

        if(value == 5) {
            type = FloorType.ACTIVE;
            floorRenderer.material.color = movingFloor;
            transform.DOMoveY(0, 1);
        }
        
    }

    public void initAnimation(float delay) {

        transform.DOMoveY(4, INIT_ANIMATION).From().SetDelay(delay);      
        floorRenderer.material.DOFade(0, INIT_ANIMATION).From().SetDelay(delay);  
    
    }

}
