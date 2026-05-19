using UnityEngine;

public class LaundaryObject : MonoBehaviour
{
    [SerializeField] private LaundaryObjectSO laundaryObjectSO;

    private ClearCounter clearCounter;
    public LaundaryObjectSO GetLaundaryObjectSO() { return laundaryObjectSO; }
    public void SetClearCounter(ClearCounter clearcounter) 
    {
        if (this.clearCounter != null) { this.clearCounter.ClearLaundaryObject(); }

        this.clearCounter = clearcounter; 
        if (clearCounter.HasLaundaryObject()) { Debug.LogError("Counter alredy has a LaundaryObject"); }
        clearCounter.SetLaundaryObject(this);

        transform.parent = clearcounter.GetLaundaryObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter() { return clearCounter; }
}
