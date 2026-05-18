using System;
using UnityEngine;
public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        Player_Controller.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }
    private void Instance_OnSelectedCounterChanged(object sender, Player_Controller.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
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
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
