using System;
using UnityEngine;
public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private LaundaryObjectSO laundaryObjectSO;

    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (!laundaryObjectParent.HasLaundaryObject())
        {
            // El jugador no lleva nada
            LaundaryObject.SpawnLaundaryObject(laundaryObjectSO, this);
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}