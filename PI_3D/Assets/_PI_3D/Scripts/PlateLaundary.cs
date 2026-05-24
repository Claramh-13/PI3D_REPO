using System.Collections.Generic;
using UnityEngine;
public class PlateLaundaryObject : LaundaryObject
{
    [SerializeField] private List<LaundaryObjectSO> validRopaSOList;
    private List<LaundaryObjectSO> laundaryObjectSOList;

    private void Awake()
    {
        laundaryObjectSOList = new List<LaundaryObjectSO>();
    }

    public bool TryAddRopa(LaundaryObjectSO laundaryObjectSO)
    {
        if (!validRopaSOList.Contains(laundaryObjectSO))
        {
            return false;
        }
        laundaryObjectSOList.Add(laundaryObjectSO);
        return true;
    }

    public List<LaundaryObjectSO> GetLaundaryObjectSOList()
    {
        return laundaryObjectSOList;
    }
}