using System;
using UnityEngine;
public class Lavadora : BaseCounter
{
    public event EventHandler OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs 
    {
        public float progressNormalized;
    }


    [SerializeField] private LaundaryObjectSO laundaryObjectSO;
    [SerializeField] private RopaMojadaSO[] ropaMojadaSOArray;

    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        Debug.Log("Lavadora HasLaundaryObject: " + HasLaundaryObject());
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
                // El jugador lleva algo, no hacemos nada
            }
            else
            {
                GetLaundaryObject().SetlaundaryObjectParent(laundaryObjectParent);
            }
        }
    }

    public override void InteractAlternate(ILaundaryObjectParent laundaryObjectParent)
    {
        if (HasLaundaryObject())
        {
            LaundaryObjectSO outputLaundaryObjectSO = GetOutputForInput(GetLaundaryObject().GetLaundaryObjectSO());
            GetLaundaryObject().DestroySelf();
            LaundaryObject.SpawnLaundaryObject(outputLaundaryObjectSO, this);
        }
    }

    private LaundaryObjectSO GetOutputForInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        foreach (RopaMojadaSO ropaMojadaSO in ropaMojadaSOArray)
        {
            if (ropaMojadaSO.input == inputLaundaryObjectSO)
            {
                return ropaMojadaSO.output;
            }
        }
        return null;
    }
}