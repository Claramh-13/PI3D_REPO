using System;
using System.Collections.Generic;
using UnityEngine;
public class PlateLaundaryObject : LaundaryObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnRopaAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public LaundaryObjectSO LaundaryObjectSO;
    }

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
        if (laundaryObjectSOList.Contains(laundaryObjectSO))
        {
            return false;
        }
        else
        {
            laundaryObjectSOList.Add(laundaryObjectSO);
            OnRopaAdded?.Invoke(this, new OnIngredientAddedEventArgs { LaundaryObjectSO = laundaryObjectSO });
        }
        return true;
    }

    public List<LaundaryObjectSO> GetLaundaryObjectSOList()
    {
        return laundaryObjectSOList;
    }
}