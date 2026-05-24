using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    
    public override void Interact(PlayerController player)
    {
        if (player.HasLaundaryObject())
        {
            if(player.GetLaundaryObject().TryGetPlate(out PlateLaundaryObject platelaundaryObject))
            {
                //only accept plates

                DeliveryManager.Instance.DeliverRecipe(platelaundaryObject);

                player.GetLaundaryObject().DestroySelf();
            }

        }
    }
}
