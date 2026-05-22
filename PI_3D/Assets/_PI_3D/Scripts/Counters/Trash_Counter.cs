using UnityEngine;

using UnityEngine;
public class TrashCounter : BaseCounter
{
    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (laundaryObjectParent.HasLaundaryObject())
        {
            laundaryObjectParent.GetLaundaryObject().DestroySelf();
        }
    }
}