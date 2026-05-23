using System;
using UnityEngine;
public class Lavadora_Progress : BaseCounter
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

    [SerializeField] private RopaMojadaSO[] ropaMojadaSOArray;
    private int lavadoraProgress;
    private float lavadoraTimer;

    private enum State
    {
        Idle,
        Whashing,
        Washed,
        Burned,
    }

    private State state;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasLaundaryObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;

                case State.Whashing:
                    RopaMojadaSO ropaMojadaSO = GetRopaMojadaSOWhithInput(GetLaundaryObject().GetLaundaryObjectSO());
                    if (ropaMojadaSO == null) return;
                    lavadoraTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = lavadoraTimer / ropaMojadaSO.lavadoraProgressMax
                    });
                    if (lavadoraTimer > ropaMojadaSO.lavadoraProgressMax)
                    {

                        GetLaundaryObject().DestroySelf();
                        LaundaryObject.SpawnLaundaryObject(ropaMojadaSO.output, this);
                        Debug.Log("Objeto lavado");
                        state = State.Washed;
                    }
                    break;

                case State.Washed:
                    break;

                case State.Burned:
                    break;
            }
            Debug.Log(state);
        }
    }

    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (!HasLaundaryObject())
        {
            if (laundaryObjectParent.HasLaundaryObject())
            {
                if (HasRopaMojadaWithInput(laundaryObjectParent.GetLaundaryObject().GetLaundaryObjectSO()))
                {
                    laundaryObjectParent.GetLaundaryObject().SetlaundaryObjectParent(this);
                    state = State.Whashing;
                    lavadoraTimer = 0f;
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = 0f
                    });
                }
            }
            else
            {
                // El jugador no lleva nada, no hacemos nada
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
                state = State.Idle;
            }
        }
    }

    public override void InteractAlternate(ILaundaryObjectParent laundaryObjectParent)
    {
        if (HasLaundaryObject())
        {
            lavadoraProgress++;
            RopaMojadaSO ropaMojadaSO = GetRopaMojadaSOWhithInput(GetLaundaryObject().GetLaundaryObjectSO());
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                progressNormalized = (float)lavadoraProgress / ropaMojadaSO.lavadoraProgressMax
            });
            if (lavadoraProgress >= ropaMojadaSO.lavadoraProgressMax)
            {
                LaundaryObjectSO outputLaundaryObjectSO = GetOutputForInput(GetLaundaryObject().GetLaundaryObjectSO());
                GetLaundaryObject().DestroySelf();
                LaundaryObject.SpawnLaundaryObject(outputLaundaryObjectSO, this);
            }
        }
    }

    private bool HasRopaMojadaWithInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        RopaMojadaSO ropaMojadaSO = GetRopaMojadaSOWhithInput(inputLaundaryObjectSO);
        return ropaMojadaSO != null;
    }

    private LaundaryObjectSO GetOutputForInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        RopaMojadaSO ropaMojadaSO = GetRopaMojadaSOWhithInput(inputLaundaryObjectSO);
        if (ropaMojadaSO != null)
        {
            return ropaMojadaSO.output;
        }
        return null;
    }

    private RopaMojadaSO GetRopaMojadaSOWhithInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        foreach (RopaMojadaSO ropaMojadaSO in ropaMojadaSOArray)
        {
            if (ropaMojadaSO.input == inputLaundaryObjectSO)
            {
                return ropaMojadaSO;
            }
        }
        return null;
    }
}