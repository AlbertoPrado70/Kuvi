using UnityEngine;
using DG.Tweening;

public class Iddle : State {

    Checkboard checkboard;

    public Iddle(Checkboard checkboard) {

        this.checkboard = checkboard; 

    }

    public override void Tick() {

        if(Input.GetMouseButtonDown(0)) {

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit) {

                Debug.Log("Hit " + hitInfo.transform.gameObject.name);     
                hitInfo.transform.gameObject.GetComponent<Cube>().transform.DOMoveX(0, 1f).SetEase(Ease.InOutQuint);

            } 

        }

    }

}
