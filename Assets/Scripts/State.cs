public abstract class State {

    public virtual void onEnter() {
        // Entrando al estado
    }

    public virtual void Tick() {
        // Actualizando estado
    }

    public virtual void onExit() {
        // Saliendo del estado
    }
    
}