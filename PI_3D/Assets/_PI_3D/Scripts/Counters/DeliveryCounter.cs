using UnityEngine;
public class DeliveryCounter : BaseCounter
{
    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        Debug.Log("DeliveryCounter tocado");
        if (laundaryObjectParent.HasLaundaryObject())
        {
            Debug.Log("Jugador tiene objeto");
            if (laundaryObjectParent.GetLaundaryObject().TryGetPlate(out PlateLaundaryObject platelaundaryObject))
            {
                Debug.Log("Es una bandeja, entregando");
                DeliveryManager.Instance.DeliverRecipe(platelaundaryObject);
                laundaryObjectParent.GetLaundaryObject().DestroySelf();
            }
            else
            {
                Debug.Log("No es una bandeja");
            }
        }
        else
        {
            Debug.Log("Jugador no tiene objeto");
        }
    }
}