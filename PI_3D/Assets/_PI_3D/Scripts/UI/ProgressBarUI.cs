using UnityEngine;
using UnityEngine.UI;
public class LavadoraProgressBarUI : MonoBehaviour
{
    [SerializeField] private Lavadora lavadora;
    [SerializeField] private Image barImage;

    private void Start()
    {
        lavadora.OnProgressChanged += Lavadora_OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void Lavadora_OnProgressChanged(object sender, Lavadora.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}