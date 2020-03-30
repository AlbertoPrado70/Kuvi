using UnityEngine;
using DG.Tweening;

public class BackgroundController : MonoBehaviour {

    private Material backgroundMaterial; 

    void Start() {
    
        backgroundMaterial = GetComponent<Renderer>().material;
        setColor();

    }

    public void setColor() {

        Color color1 = Random.ColorHSV(0, 1, 0.7f, 1, 0.8f, 0.9f);
        Color color2 = Random.ColorHSV(0, 1, 0.7f, 1, 0.4f, 0.5f);

        backgroundMaterial.DOColor(color1, "_Color1", 1);
        backgroundMaterial.DOColor(color2, "_Color2", 1);


    }

}
