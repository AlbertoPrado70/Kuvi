using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public const float FADE_ANIMATION = 0.8f; 

    public Transform completeTransform; 
    public Image completeFade;

    public TextMeshProUGUI levelMessage;

    public bool completedFadedAnimation; 

    void Start() {

        completedFadedAnimation = false; 

    }

    public void completeAnimation() {

        completeTransform.localScale = Vector3.zero;

        completeTransform.DOScale(20, FADE_ANIMATION);     
        completeFade.DOFade(0.5f, FADE_ANIMATION);
        completeFade.DOFade(0, FADE_ANIMATION).SetDelay(FADE_ANIMATION);
    
        completedFadedAnimation = true; 
    
    }

    public void showLevelMessage(string message) {

        levelMessage.SetText(message);
        levelMessage.DOFade(0, 0);

        levelMessage.DOFade(1, 1).SetDelay(1);
        levelMessage.DOFade(0, 1).SetDelay(3);

    }

}
