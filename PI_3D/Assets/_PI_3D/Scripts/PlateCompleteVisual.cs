using System.Collections.Generic;
using UnityEngine;
public class PlateCompleteVisual : MonoBehaviour
{
    [System.Serializable]
    public class LaundaryObjectSO_GameObject
    {
        public LaundaryObjectSO laundaryObjectSO;
        public GameObject gameObject;
    }
    [SerializeField] private PlateLaundaryObject plateLaundaryObject;
    [SerializeField] private List<LaundaryObjectSO_GameObject> laundaryObjectSOGameObjectList;

    private void Start()
    {
        plateLaundaryObject.OnRopaAdded += PlateLaundaryObject_OnRopaAdded;
        foreach (LaundaryObjectSO_GameObject laundaryObjectSO_GameObject in laundaryObjectSOGameObjectList)
        {
            laundaryObjectSO_GameObject.gameObject.SetActive(false);
        }
    }

    private void PlateLaundaryObject_OnRopaAdded(object sender, PlateLaundaryObject.OnIngredientAddedEventArgs e)
    {
        foreach (LaundaryObjectSO_GameObject laundaryObjectSO_GameObject in laundaryObjectSOGameObjectList)
        {
            if (laundaryObjectSO_GameObject.laundaryObjectSO == e.LaundaryObjectSO)
            {
                laundaryObjectSO_GameObject.gameObject.SetActive(true);
            }
        }
    }
}