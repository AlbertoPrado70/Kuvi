using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public Kuvi kuvi; 
    public Image blackPanel; 

    public Button backButton; 
    public Button nextButton;
    public Button menuButton; 

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelMessage;

    public Sequence levelMessageSequence; 

    public bool lastLevel;
    public bool nextLevel; 

    void Awake() {
        lastLevel = false; 
        nextLevel = false; 
        levelMessage.SetText("");
    }

    public void fadeOutPanel() {
        blackPanel.gameObject.SetActive(true);
        blackPanel.DOFade(0, 1).OnComplete(() => blackPanel.gameObject.SetActive(false)); 
    }

    public void goToLastLevel() {

        if(kuvi.actualLevel > 0) {
            lastLevel = true; 
            kuvi.actualLevel--;
            setMenuActive(false); 
            setLevelText((kuvi.actualLevel + 1).ToString());
        }

    }

    public void goToNextLevel() {

        if(kuvi.actualLevel < Level.json.Length - 1) {
            nextLevel = true; 
            kuvi.actualLevel++;
            setMenuActive(false); 
            setLevelText((kuvi.actualLevel + 1).ToString());
        }

    }

    public void setLevelText(string level) {
        levelText.SetText(level);
    }

    public void showLevelMessage(string message) {

        levelMessage.SetText(message);
        levelMessageSequence = DOTween.Sequence();

        levelMessageSequence.Append(levelMessage.DOFade(0, 0));
        levelMessageSequence.Append(levelMessage.DOFade(1, 1));
        levelMessageSequence.Insert(3, levelMessage.DOFade(0, 1));

    }

    public void stopMessageAnimations() {
        levelMessageSequence.Complete();
    }

    public void setMenuActive(bool state) {
        backButton.interactable = state; 
        nextButton.interactable = state;
    }

}

