using UnityEngine;
using DG.Tweening;
using TMPro;

public class MessagePanel : MonoBehaviour {

    public GameObject canvas;
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI title;
    public TextMeshProUGUI message;

    public void showMessage(string title, string message) {
        canvas.SetActive(true);
        this.title.SetText(title);
        this.message.SetText(message);
        canvasGroup.DOFade(1, 0.5f);
    }

    public void hideMessage() {
        canvasGroup.DOFade(0, 0.5f).OnComplete(() => canvas.SetActive(false));
    }

  
}
