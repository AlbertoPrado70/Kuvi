using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public const float OPEN_BUTTON_DURATION = 0.35f; 

    public Kuvi kuvi; 
    public Image blackPanel; 

    public Button backButton; 
    public Button nextButton;
    public Button menuButton; 

    public Button[] menuButtons; 

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelMessage;

    public Sequence levelMessageSequence; 

    public bool lastLevel;
    public bool nextLevel; 


    public AnimationCurve menuButtonEase;

    void Awake() {

        lastLevel = false; 
        nextLevel = false; 
        levelMessage.SetText("");

        // Posicion de los botones del menu
        float distance = 180; 
        float teta = 0; 
        Vector3 buttonPosition = new Vector3();

        foreach(Button button in menuButtons) {

            float x = distance * Mathf.Cos(teta); 
            float y = distance * Mathf.Sin(teta);             

            buttonPosition.Set(x, y, 0); 
            button.GetComponent<RectTransform>().anchoredPosition = buttonPosition;
            teta += Mathf.PI / 4;

        }

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

    public void openMenuAnimation() {

        float delay = 0; 

        foreach(Button button in menuButtons) {

            button.gameObject.SetActive(true);

            Sequence sequence = DOTween.Sequence(); 
            sequence.Insert(delay, button.GetComponent<RectTransform>().DOAnchorPos(Vector3.zero, OPEN_BUTTON_DURATION).From().SetEase(menuButtonEase));
            sequence.Insert(delay, button.GetComponent<RectTransform>().DOScale(Vector3.zero, OPEN_BUTTON_DURATION).From().SetEase(menuButtonEase));
            sequence.Insert(delay, button.image.DOFade(0, OPEN_BUTTON_DURATION + 0.5f).From());

            delay += 0.03f;

        }

    }

}

