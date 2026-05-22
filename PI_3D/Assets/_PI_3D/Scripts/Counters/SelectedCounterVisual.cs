using System;
using UnityEngine;
public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
    private void Start()
    {
        Player_Controller.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }
    private void Instance_OnSelectedCounterChanged(object sender, Player_Controller.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }

        Debug.Log("Selected: " + e.selectedCounter + " | BaseCounter: " + baseCounter);
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }


    private void Show()
    {
        foreach(GameObject visualGameObject in visualGameObjectArray)
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        foreach(GameObject visualGameObject in visualGameObjectArray)
        visualGameObject.SetActive(false);
    }

  
}
