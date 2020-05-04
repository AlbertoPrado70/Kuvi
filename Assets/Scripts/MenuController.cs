using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public const float OPEN_BUTTON_DURATION = 0.35f; 
    public const float RADIAL_BUTTON_DISTANCE = 170;

    public Kuvi kuvi; 
    public Image blackPanel; 

    public Button backButton; 
    public Button nextButton;
    public Image soundButton;

    public Sprite muteIcon; 
    public Sprite soundIcon; 
    
    public Image menuIcon; 
    public GameObject[] menuButtons;
    public RectTransform[] rectTransformButtons;  

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelMessage;

    public GameObject thanksCanvas; 
    public CanvasGroup canvasGroup; 

    public Sequence levelMessageSequence; 

    public bool menuIsOpen = false; 
    public bool isAutoSolving = false; 

    public float iconRotation = 0; 

    public AnimationCurve menuButtonEase;

    void Awake() {

        levelMessage.SetText("");
        rectTransformButtons = new RectTransform[5];

        for(int i = 0; i < menuButtons.Length; i++) {
            rectTransformButtons[i] = menuButtons[i].GetComponent<RectTransform>();
        }

        soundButton.sprite = (kuvi.preferences.muted) ? muteIcon : soundIcon; 

    }

    // FadeOut del inicio 
    public void fadeOutPanel() {
        blackPanel.gameObject.SetActive(true);
        blackPanel.DOFade(0, 1).OnComplete(() => blackPanel.gameObject.SetActive(false)); 
    }

    // Ir al nivel anterior
    public void goToLastLevel() {
        if(kuvi.preferences.actualLevel > 0) { 
            kuvi.preferences.actualLevel--;
            kuvi.preferences.saveCompletedLevel();
            kuvi.setState(kuvi.loadLevelState);
        }
    }

    // Boton para ir al siguiente nivel
    public void goToNextLevel() {
        if(kuvi.preferences.actualLevel < Level.json.Length - 1) {
            kuvi.preferences.actualLevel++;
            kuvi.preferences.saveCompletedLevel();
            kuvi.setState(kuvi.loadLevelState);
        }
    }

    // Establece el numero de nivel en la parte superior 
    public void setLevelIndicator(string level) {
        levelText.SetText(level);
    }

    // Muestra el mensaje del nivel
    public void showLevelMessage(string message) {

        levelMessage.SetText(message);
        levelMessageSequence = DOTween.Sequence();

        levelMessageSequence.Append(levelMessage.DOFade(0, 0));
        levelMessageSequence.Append(levelMessage.DOFade(1, 1));
        levelMessageSequence.Insert(6, levelMessage.DOFade(0, 1));

    }

    // Detiene el mensaje
    public void stopMessageAnimations() {
        levelMessageSequence.Complete();
    }

    public void setMenuActive(bool state, int level) {

        if(state && level > 0) {
            backButton.interactable = true; 
        }

        if(state && level < Level.json.Length - 1) {
            nextButton.interactable = true; 
        }

        if(!state) {
            backButton.interactable = false; 
            nextButton.interactable = false;
        }

        
    }

    

    // Establece las animaciones del menu
    public void setMenuAnimation() {

        iconRotation += 90;
        menuIcon.transform.DORotate(new Vector3(0, 0, iconRotation), 0.25f);
        menuIcon.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f); 
        menuIcon.transform.DOScale(Vector3.one, 0.5f).SetDelay(0.1f); 

        // Abrimos el menu
        if(!menuIsOpen) {

            Vector3 buttonPosition = new Vector3();

            float delay = 0; 
            float teta = 0; 

            for(int i = 0; i < menuButtons.Length; i++) {

                menuButtons[i].gameObject.SetActive(true);

                float x = RADIAL_BUTTON_DISTANCE * Mathf.Cos(teta); 
                float y = RADIAL_BUTTON_DISTANCE * Mathf.Sin(teta);             

                buttonPosition.Set(x, y, 0); 

                rectTransformButtons[i].anchoredPosition = Vector3.zero;
                rectTransformButtons[i].localScale = Vector3.zero;
                rectTransformButtons[i].gameObject.GetComponent<Button>().image.color = new Color(1, 1, 1, 0);
                
                Sequence sequence = DOTween.Sequence(); 
                sequence.Insert(delay, rectTransformButtons[i].DOAnchorPos(buttonPosition, OPEN_BUTTON_DURATION).SetEase(menuButtonEase));
                sequence.Insert(delay, rectTransformButtons[i].DOScale(Vector3.one, OPEN_BUTTON_DURATION).SetEase(menuButtonEase));
                sequence.Insert(delay, menuButtons[i].gameObject.GetComponent<Button>().image.DOFade(1, OPEN_BUTTON_DURATION));

                delay += 0.03f;
                teta += Mathf.PI / 4;

            }

            menuIsOpen = true; 

        }

        // Cerramos el menu
        else {

            for(int i = 0; i < menuButtons.Length; i++) {
                
                Sequence sequence = DOTween.Sequence(); 
                sequence.Insert(0, rectTransformButtons[i].DOAnchorPos(Vector3.zero, OPEN_BUTTON_DURATION).SetEase(menuButtonEase));
                sequence.Insert(0, rectTransformButtons[i].DOScale(Vector3.zero, OPEN_BUTTON_DURATION).SetEase(menuButtonEase));
                sequence.Insert(0, menuButtons[i].gameObject.GetComponent<Button>().image.DOFade(0, OPEN_BUTTON_DURATION));

            }

            menuIsOpen = false;

        }

    }

    // Reinicia el nivel 
    public void resetLevel() {
        kuvi.setState(kuvi.loadLevelState);
        isAutoSolving = false;
        setMenuAnimation();
    }

    // Iniciamos el auto solver
    public void autoSolveLevel() {
        isAutoSolving = true;
        setMenuAnimation();
    }    

    // Cambia el volumen del dispositivo
    public void setVolumen() {

        if(AudioListener.volume == 1) {
            AudioListener.volume = 0; 
            soundButton.sprite = muteIcon; 
            kuvi.preferences.saveVolumeLevel(true);
        }

        else {
            AudioListener.volume = 1; 
            soundButton.sprite = soundIcon; 
            kuvi.preferences.saveVolumeLevel(false);
        }

        setMenuAnimation();
    }

    // Abrimos el panel de creditos
    public void openThanksPanel() {
        thanksCanvas.SetActive(true);
        canvasGroup.DOFade(1, 0.5f);
        setMenuAnimation();
    }

}

