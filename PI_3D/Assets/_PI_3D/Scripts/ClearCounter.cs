using UnityEngine;

public class ClearCounter : MonoBehaviour
{

   [SerializeField] private LaundaryObjectSO laundaryObjectSO;
   [SerializeField] private Transform counterTopPoint;
   [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private LaundaryObject laundaryObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (laundaryObject != null)
            {
                laundaryObject.SetClearCounter(secondClearCounter);
               
            }
        }
    }
    public void Interact() 
    {
        if (laundaryObject == null)
        {
            Transform laudaryObjectTransform = Instantiate(laundaryObjectSO.prefab, counterTopPoint);
            laudaryObjectTransform.GetComponent<LaundaryObject>().SetClearCounter(this);
            laudaryObjectTransform.localPosition = Vector3.zero;

        } else { Debug.Log(laundaryObject.GetClearCounter()); }
    }

    public Transform GetLaundaryObjectFollowTransform() { return counterTopPoint; }
    public void SetLaundaryObject(LaundaryObject laundaryObject)
    {
        this.laundaryObject = laundaryObject;
    }

    public LaundaryObject GetLaundaryObject() { return laundaryObject; }
    public void ClearLaundaryObject()
    {
        laundaryObject = null;
    }

    public bool HasLaundaryObject() { return laundaryObject != null; }
}
