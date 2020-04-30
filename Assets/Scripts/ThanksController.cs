using TMPro;
using UnityEngine;
using DG.Tweening; 

public class ThanksController : MonoBehaviour {

    public CanvasGroup thanksPanel; 

    public TextMeshProUGUI playerText;
    public TextMeshProUGUI creditsText;
    public TextMeshProUGUI moreText;

    void Start() {
        playerText.SetText(Messages.getMenuMessage(0));
        creditsText.SetText(Messages.getMenuMessage(1));
        moreText.SetText(Messages.getMenuMessage(2));
    }

    public void closeThanksMenu() {
        thanksPanel.DOFade(0, 0.5f).OnComplete(() => thanksPanel.gameObject.SetActive(false));
    }
    
    public void rateUs() {
        Application.OpenURL("https://www.google.com");
    }

    public void openRocketeor() {
        Application.OpenURL("https://www.google.com");
    }

}
