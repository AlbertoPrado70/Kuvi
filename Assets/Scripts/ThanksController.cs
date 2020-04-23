using UnityEngine;
using DG.Tweening; 
using UnityEngine.UI;


public class ThanksController : MonoBehaviour {

    public CanvasGroup thanksPanel; 

    public void closeThanksMenu() {
        thanksPanel.DOFade(0, 0.5f).OnComplete(() => thanksPanel.gameObject.SetActive(false));
    }
    
}
