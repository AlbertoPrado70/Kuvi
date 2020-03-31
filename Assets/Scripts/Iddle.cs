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

                Cube c = hitInfo.collider.gameObject.GetComponent<Cube>();
                Debug.Log("Cube" + c.row + c.column);
                checkboard.moveCube(Checkboard.Move.RIGHT, c.row, c.column);

            } 

        }

        if(Input.GetKeyDown("d") || Input.touchCount > 0) {

            checkboard.moveCube(Checkboard.Move.RIGHT, 0, 0);

        }

    }

}
