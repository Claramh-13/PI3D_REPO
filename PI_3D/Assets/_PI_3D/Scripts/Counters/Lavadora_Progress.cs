using System;
using UnityEngine;
public class Lavadora_Progress : BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    [SerializeField] private RopaMojadaSO[] ropaMojadaSOArray;
    [SerializeField] private RopaQuemadaSO[] ropaQuemadaSOArray;
    private float lavadoraTimer;
    private float burningTimer;

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
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = lavadoraTimer / (float)ropaMojadaSO.lavadoraProgressMax
                    });
                    if (lavadoraTimer > (float)ropaMojadaSO.lavadoraProgressMax)
                    {
                        GetLaundaryObject().DestroySelf();
                        LaundaryObject.SpawnLaundaryObject(ropaMojadaSO.output, this);
                        state = State.Washed;
                        burningTimer = 0f;
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0.01f
                        });
                    }
                    break;

                case State.Washed:
                    RopaQuemadaSO ropaQuemadaSO = GetRopaQuemadaSOWhithInput(GetLaundaryObject().GetLaundaryObjectSO());
                    if (ropaQuemadaSO == null) return;
                    burningTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = burningTimer / ropaQuemadaSO.burningTimerMax
                    });
                    if (burningTimer > ropaQuemadaSO.burningTimerMax)
                    {
                        GetLaundaryObject().DestroySelf();
                        LaundaryObject.SpawnLaundaryObject(ropaQuemadaSO.output, this);
                        state = State.Burned;
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0f
                        });
                    }
                    break;

                case State.Burned:
                    break;
            }
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
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = 0f
                    });
                }
            }
        }
        else
        {
            if (!laundaryObjectParent.HasLaundaryObject())
            {
                GetLaundaryObject().SetlaundaryObjectParent(laundaryObjectParent);
                state = State.Idle;
            }
        }
    }

    private bool HasRopaMojadaWithInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        return GetRopaMojadaSOWhithInput(inputLaundaryObjectSO) != null;
    }

    private LaundaryObjectSO GetOutputForInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        RopaMojadaSO ropaMojadaSO = GetRopaMojadaSOWhithInput(inputLaundaryObjectSO);
        if (ropaMojadaSO != null) return ropaMojadaSO.output;
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

    private RopaQuemadaSO GetRopaQuemadaSOWhithInput(LaundaryObjectSO inputLaundaryObjectSO)
    {
        foreach (RopaQuemadaSO ropaQuemadaSO in ropaQuemadaSOArray)
        {
            if (ropaQuemadaSO.input == inputLaundaryObjectSO)
            {
                return ropaQuemadaSO;
            }
        }
        return null;
    }

    public bool IsWashed()
    {
        return state == State.Washed;
    }
}