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
}
