using UnityEngine;
public class ContainerCounter : BaseCounter
{
    [SerializeField] private LaundaryObjectSO laundaryObjectSO;
   
    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
       
            Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab);
            laudaryObjectTransform.GetComponent<LaundaryObject>().SetlaundaryObjectParent(laundaryObjectParent);
         
        
        
    }
   
}