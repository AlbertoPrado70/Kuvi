using UnityEngine;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelMessage;

    public bool lastLevel;
    public bool nextLevel; 

    void Start() {

        lastLevel = false; 
        nextLevel = false; 

    }

    public void goToLastLevel() {
        lastLevel = true; 
        Debug.Log("back");
    }

    public void goToNextLevel() {
        nextLevel = true; 
        Debug.Log("next");
    }

    public void setLevelText(string level) {

        levelText.SetText(level);

    }

    public void showLevelMessage(string message) {

        levelMessage.SetText(message);
        levelMessage.DOFade(0, 0);

        levelMessage.DOFade(1, 1).SetDelay(1);
        levelMessage.DOFade(0, 1).SetDelay(4);

    }

}
