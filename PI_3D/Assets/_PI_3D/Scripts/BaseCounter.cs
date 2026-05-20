using UnityEngine;
public class BaseCounter : MonoBehaviour
{
    public virtual void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        Debug.LogError("BaseCounter.Interact();");
    }
}