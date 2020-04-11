using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public Image blackPanel; 

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelMessage;

    public bool lastLevel;
    public bool nextLevel; 

    void Start() {

        lastLevel = false; 
        nextLevel = false; 

    }

    public void fadeOutPanel() {
        blackPanel.color = new Color(0, 0, 0, 1); 
        blackPanel.DOFade(0, 1).OnComplete(() => blackPanel.gameObject.SetActive(false)); 
    }

    public void goToLastLevel() {
        lastLevel = true; 
    }

    public void goToNextLevel() {
        nextLevel = true; 
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

    public void stopMessageAnimations() {
        levelMessage.DOComplete();
    }

}
