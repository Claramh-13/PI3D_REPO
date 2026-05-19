using UnityEngine;

public class ClearCounter : MonoBehaviour
{

   [SerializeField] private Transform CalcetinesPrefab;
   [SerializeField] private Transform counterTopPoint;
    public void Interact() 
    {
        Debug.Log("interact");
        Transform CalcetinesTransform = Instantiate(CalcetinesPrefab, counterTopPoint);
        CalcetinesTransform.localPosition = Vector3.zero;
    }
}
