using UnityEngine;

public interface ILaundaryObjectParent
{
    public Transform GetLaundaryObjectFollowTransform();
    public void SetLaundaryObject(LaundaryObject laundaryObject);

    public LaundaryObject GetLaundaryObject();
    public void ClearLaundaryObject();

    public bool HasLaundaryObject();
}

  
