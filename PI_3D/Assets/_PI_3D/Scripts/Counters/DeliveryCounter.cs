using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeliveryCounter : BaseCounter
{
    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (laundaryObjectParent.HasLaundaryObject())
        {
            
             if (laundaryObjectParent.GetLaundaryObject().TryGetPlate(out PlateLaundaryObject platelaundaryObject))
             {
                 DeliveryManager.Instance.DeliverRecipe(platelaundaryObject);
                 laundaryObjectParent.GetLaundaryObject().DestroySelf();
             }
        }
    }
}