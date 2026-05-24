using UnityEngine;

public class LaundaryObject : MonoBehaviour
{
    [SerializeField] private LaundaryObjectSO laundaryObjectSO;

    private ILaundaryObjectParent laundaryObjectParent;
    public LaundaryObjectSO GetLaundaryObjectSO() { return laundaryObjectSO; }
    public void SetlaundaryObjectParent(ILaundaryObjectParent laundaryObjectParent) 
    {
        if (this.laundaryObjectParent != null) { this.laundaryObjectParent.ClearLaundaryObject(); }

        this.laundaryObjectParent = laundaryObjectParent; 
        if (laundaryObjectParent.HasLaundaryObject()) { Debug.LogError("ILaundaryObjectParent alredy has a LaundaryObject"); }
        laundaryObjectParent.SetLaundaryObject(this);

        transform.parent = laundaryObjectParent.GetLaundaryObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ILaundaryObjectParent GetLaundaryObjectParent() { return laundaryObjectParent; }

    public void DestroySelf() 
    {
      laundaryObjectParent.ClearLaundaryObject() ;
        Destroy(gameObject);
    
    }


    public static LaundaryObject SpawnLaundaryObject(LaundaryObjectSO laundaryObjectSO, ILaundaryObjectParent laundaryObjectParent) 
    {
        Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab);
        LaundaryObject laundaryObject = laudaryObjectTransform.GetComponent<LaundaryObject>();
        laundaryObject.SetlaundaryObjectParent(laundaryObjectParent);

        return laundaryObject;

    }

    public bool TryGetPlate(out PlateLaundaryObject plateLaundaryObject)
    {
        plateLaundaryObject = GetComponent<PlateLaundaryObject>();
        return plateLaundaryObject != null;
    }
}
