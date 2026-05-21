using UnityEngine;

public class Lavadora : BaseCounter {

    [SerializeField] private LaundaryObjectSO laundaryObjectSO;

    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (!HasLaundaryObject())
        {
            // No hay objeto en la encimera
            if (laundaryObjectParent.HasLaundaryObject())
            {
                // El jugador lleva algo, lo pone en la encimera
                laundaryObjectParent.GetLaundaryObject().SetlaundaryObjectParent(this);
            }
            else
            {
                // El jugador no lleva nada, spawneamos objeto
                if (laundaryObjectSO != null)
                {
                    Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab);
                    laudaryObjectTransform.GetComponent<LaundaryObject>().SetlaundaryObjectParent(this);
                }
            }
        }
        else
        {
            // Hay un objeto en la encimera
            if (laundaryObjectParent.HasLaundaryObject())
            {
                // El jugador lleva algo, no hacemos nada
            }
            else
            {
                // El jugador no lleva nada, coge el objeto
                GetLaundaryObject().SetlaundaryObjectParent(laundaryObjectParent);
            }
        }
    }
   
}
