using UnityEngine;
using DG.Tweening;
using TMPro;

public class MenuController : MonoBehaviour {

    public TextMeshProUGUI levelMessage;

    public void showLevelMessage(string message) {

        levelMessage.SetText(message);
        levelMessage.DOFade(0, 0);

        levelMessage.DOFade(1, 1).SetDelay(1);
        levelMessage.DOFade(0, 1).SetDelay(4);

    }

}
