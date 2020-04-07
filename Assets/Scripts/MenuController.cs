using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour {

    public const float FADE_ANIMATION = 0.8f; 

    public Transform completeTransform; 
    public Image completeFade;

    public bool completedFadedAnimation; 

    void Start() {

        completedFadedAnimation = false; 

    }

    public void completeAnimation() {

        completeTransform.localScale = Vector3.zero;

        completeTransform.DOScale(20, FADE_ANIMATION);     
        completeFade.DOFade(0.8f, FADE_ANIMATION);
        completeFade.DOFade(0, FADE_ANIMATION).SetDelay(FADE_ANIMATION - 0.1f);
    
        completedFadedAnimation = true; 
    
    }

    void Update() {

        if(Input.GetKeyDown("f")) {
            completeAnimation();
        }
        
    }

}
