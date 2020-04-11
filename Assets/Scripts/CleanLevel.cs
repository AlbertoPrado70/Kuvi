using UnityEngine;

public class CleanLevel : State{

    private Kuvi kuvi; 

    public CleanLevel(Kuvi kuvi) {
        this.kuvi = kuvi; 
    }

    public override void Tick() {
        Debug.Log("Limpiando nivel"); 
    }

}
