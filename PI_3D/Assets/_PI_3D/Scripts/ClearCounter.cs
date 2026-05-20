using UnityEngine;
public class ClearCounter : MonoBehaviour, ILaundaryObjectParent
{
    [SerializeField] private LaundaryObjectSO laundaryObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private LaundaryObject laundaryObject;
    
    public void Interact(Player_Controller player)
    {
        if (laundaryObject == null)
        {
            Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab, counterTopPoint);
            laudaryObjectTransform.GetComponent<LaundaryObject>().SetlaundaryObjectParent(this);
            laudaryObjectTransform.localPosition = Vector3.zero;
        }
        else
        {
            laundaryObject.SetlaundaryObjectParent(player);
        }
    }
    public Transform GetLaundaryObjectFollowTransform() { return counterTopPoint; }
    public void SetLaundaryObject(LaundaryObject laundaryObject) { this.laundaryObject = laundaryObject; }
    public LaundaryObject GetLaundaryObject() { return laundaryObject; }
    public void ClearLaundaryObject() { laundaryObject = null; }
    public bool HasLaundaryObject() { return laundaryObject != null; }
}