using UnityEngine.UI;
using UnityEngine;
using DG.Tweening; 
using TMPro;

public class EndPanelController : MonoBehaviour {

    public CanvasGroup canvas; 
    public TextMeshProUGUI title; 
    public TextMeshProUGUI subtitle; 
    public TextMeshProUGUI message; 
    public Image rocketeor; 
    public Image back; 

    void Start() {

        title.SetText(Messages.getEndingMessage(0));
        subtitle.SetText(Messages.getEndingMessage(1));
        message.SetText(Messages.getEndingMessage(2));

    }

    public void showPanel() {

        gameObject.SetActive(true);

        title.DOFade(0, 0);
        subtitle.DOFade(0, 0); 
        message.DOFade(0, 0);
        rocketeor.DOFade(0, 0); 
        back.DOFade(0, 0);

        canvas.DOFade(1, 1).SetDelay(1); 
        title.DOFade(1, 1).SetDelay(2); 
        subtitle.DOFade(1, 1).SetDelay(4); 
        message.DOFade(1, 1).SetDelay(6);
        rocketeor.DOFade(1, 1).SetDelay(8); 
        back.DOFade(1, 1).SetDelay(8);

    }

    public void openRocketeorPage() {
        Application.OpenURL("https://www.rocketeor.com");
    }

    public void hidePanel() {
        canvas.DOFade(0, 1).OnComplete(() => gameObject.SetActive(false)); 
    }

}
