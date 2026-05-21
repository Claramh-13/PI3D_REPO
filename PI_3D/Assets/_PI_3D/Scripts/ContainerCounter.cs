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
            Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab);
            laudaryObjectTransform.GetComponent<LaundaryObject>().SetlaundaryObjectParent(laundaryObjectParent);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}