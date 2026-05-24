using UnityEngine;
public class ClearCounter : BaseCounter
{
    [SerializeField] private LaundaryObjectSO laundaryObjectSO;
    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (!HasLaundaryObject())
        {
            if (laundaryObjectParent.HasLaundaryObject())
            {
                laundaryObjectParent.GetLaundaryObject().SetlaundaryObjectParent(this);
            }
            else
            {
                if (laundaryObjectSO != null)
                {
                    Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab);
                    laudaryObjectTransform.GetComponent<LaundaryObject>().SetlaundaryObjectParent(this);
                }
            }
        }
        else
        {
            if (laundaryObjectParent.HasLaundaryObject())
            {
                if (laundaryObjectParent.GetLaundaryObject().TryGetPlate(out PlateLaundaryObject plateLaundaryObject))
                {
                    if (plateLaundaryObject.TryAddRopa(GetLaundaryObject().GetLaundaryObjectSO()))
                    {
                        GetLaundaryObject().DestroySelf();
                    }
                }
                else if (GetLaundaryObject().TryGetPlate(out PlateLaundaryObject counterPlateLaundaryObject))
                {
                    if (counterPlateLaundaryObject.TryAddRopa(laundaryObjectParent.GetLaundaryObject().GetLaundaryObjectSO()))
                    {
                        laundaryObjectParent.GetLaundaryObject().DestroySelf();
                    }
                }
            }
            else
            {
                GetLaundaryObject().SetlaundaryObjectParent(laundaryObjectParent);
            }
        }
    }
}