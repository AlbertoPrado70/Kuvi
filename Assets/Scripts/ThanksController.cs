using TMPro;
using UnityEngine;
using DG.Tweening; 

public class ThanksController : MonoBehaviour {

    public CanvasGroup thanksPanel; 

    public TextMeshProUGUI aboutUs;
    public TextMeshProUGUI thanksTitle;
    public TextMeshProUGUI parentsTitle;
    public TextMeshProUGUI parentsText;
    public TextMeshProUGUI chandyText;
    public TextMeshProUGUI moreText; 

    void Start() {
        aboutUs.SetText(Messages.getMenuMessage(0));
        thanksTitle.SetText(Messages.getMenuMessage(1));
        parentsTitle.SetText(Messages.getMenuMessage(2));
        parentsText.SetText(Messages.getMenuMessage(3));
        chandyText.SetText(Messages.getMenuMessage(4));
        moreText.SetText(Messages.getMenuMessage(5));
    }

    public void closeThanksMenu() {
        thanksPanel.DOFade(0, 0.5f).OnComplete(() => thanksPanel.gameObject.SetActive(false));
    }
    
    public void rateUs() {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }

    public void openRocketeor() {
        Application.OpenURL("https://www.rocketeor.com");
    }

}
