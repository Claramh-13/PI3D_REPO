using UnityEngine;
public class BaseCounter : MonoBehaviour, ILaundaryObjectParent
{
    [SerializeField] private Transform counterTopPoint;
    private LaundaryObject laundaryObject;
    public virtual void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        Debug.LogError("BaseCounter.Interact();");
    }

    public virtual void InteractAlternate(ILaundaryObjectParent laundaryObjectParent)
    {
        //Debug.LogError("BaseCounter.InteractAlternate();");
    }

    public Transform GetLaundaryObjectFollowTransform() { return counterTopPoint; }
    public void SetLaundaryObject(LaundaryObject laundaryObject) { this.laundaryObject = laundaryObject; }
    public LaundaryObject GetLaundaryObject() { return laundaryObject; }
    public void ClearLaundaryObject() { laundaryObject = null; }
    public bool HasLaundaryObject() { return laundaryObject != null; }
}