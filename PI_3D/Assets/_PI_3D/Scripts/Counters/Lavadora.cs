using System;
using UnityEngine;
public class Lavadora : BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
   


    [SerializeField] private LaundaryObjectSO laundaryObjectSO;
    [SerializeField] private RopaMojadaSO[] ropaMojadaSOArray;

    private int lavadoraProgress;
    
    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        Debug.Log("Lavadora HasLaundaryObject: " + HasLaundaryObject());
        if (!HasLaundaryObject())
        {
            if (laundaryObjectParent.HasLaundaryObject())
            {
                laundaryObjectParent.GetLaundaryObject().SetlaundaryObjectParent(this);
                lavadoraProgress = 0;
                RopaMojadaSO ropaMojadaSO1 = GetRopaMojadaSOWhithInput(GetLaundaryObject().GetLaundaryObjectSO());
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs { progressNormalized = (float)lavadoraProgress / ropaMojadaSO1.lavadoraProgressMax });
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
            lavadoraProgress++;
            RopaMojadaSO ropaMojadaSO1 = GetRopaMojadaSOWhithInput(GetLaundaryObject().GetLaundaryObjectSO());
            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs { progressNormalized = (float)lavadoraProgress / ropaMojadaSO1.lavadoraProgressMax });

            if (lavadoraProgress >= ropaMojadaSO1.lavadoraProgressMax)
            {
                LaundaryObjectSO outputLaundaryObjectSO = GetOutputForInput(GetLaundaryObject().GetLaundaryObjectSO());
                GetLaundaryObject().DestroySelf();
                LaundaryObject.SpawnLaundaryObject(outputLaundaryObjectSO, this);
            }
        }
    }

    private LaundaryObjectSO GetOutputForInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        RopaMojadaSO ropaMojadaSO1 = GetRopaMojadaSOWhithInput(inputLaundaryObjectSO);
        if (ropaMojadaSO1 != null)
        {
            return ropaMojadaSO1.output;
        }
        else
        {
            return null;
        }
    }

    private RopaMojadaSO GetRopaMojadaSOWhithInput(LaundaryObjectSO laundaryObjectSO)
    {
        foreach (RopaMojadaSO ropaMojadaSO in ropaMojadaSOArray)
        {
            if (ropaMojadaSO.input == laundaryObjectSO)
            {
                return ropaMojadaSO;
            }
        }
        return null;
    }
}