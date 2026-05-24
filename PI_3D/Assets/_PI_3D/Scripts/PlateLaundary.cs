using System.Collections.Generic;
using UnityEngine;

public class PlateLaundaryObject : MonoBehaviour
{
    [SerializeField] private List<LaundaryObjectSO> laundaryObjectSOList;

    public List<LaundaryObjectSO> GetLaundaryObjectSOList()
    {
        return laundaryObjectSOList;
    }
}
