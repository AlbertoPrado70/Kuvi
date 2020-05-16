using UnityEngine;
using UnityEngine.Purchasing;

public class Purchase : MonoBehaviour, IStoreListener {

    public static string noAds = "kuvi_premium";

    public Kuvi kuvi;
    public IStoreController storeController;  
    private bool IsInitialized = false; 

    // Panel de mensajes
    public MessagePanel messagePanel; 

    // Inicializamos el servicio de ventas
    void Start() { 
        if(!IsInitialized) {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(noAds, ProductType.NonConsumable);
            UnityPurchasing.Initialize(this, builder);
        }
    }

    // Compramos el producto 
    public void buyNoAds() {

        if(kuvi.preferences.isPremium) {
            messagePanel.showMessage("Kuvi premium", "You are a premium user. No need to buy again.");
        }

        if(IsInitialized && storeController != null && !kuvi.preferences.isPremium) {
            Product product = storeController.products.WithID(noAds);
            if (product != null && product.availableToPurchase) {
                storeController.InitiatePurchase(product);
            }
        }

        

    }

    // Comprueba si se inicializo correctamente. Obtenemos la referencia al controlador
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
        Debug.Log("Purchases: Inicializado");
        storeController = controller;
        IsInitialized = true; 
    }

    // Fallo la inicialización
    public void OnInitializeFailed(InitializationFailureReason error) {
        Debug.Log("Purchases: Error al inicializar");
        IsInitialized = false; 
    }

    // Si la compra fue un exito desactivamos los anuncios. Como solo existe un producto 
    // no creo que sea necesario verificar que tipo o que ID tiene.
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
        kuvi.preferences.saveUserPremium(); 
        messagePanel.showMessage("Purchase completed", "Ads disabled. Thank you! <3");
        return PurchaseProcessingResult.Complete;
    }

    // En caso de que la compra falle
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
        Debug.Log("Purchases: Imposible finalizar la operación. " + failureReason); 
        messagePanel.showMessage("Error on purchase", "There was a problem with the transaction. Try again.");
    }

}
