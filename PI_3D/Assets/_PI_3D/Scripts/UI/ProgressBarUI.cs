using UnityEngine;
using UnityEngine.UI;
public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;
    private IHasProgress hasProgress;
    private Lavadora_Progress lavadora;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        lavadora = hasProgressGameObject.GetComponent<Lavadora_Progress>();
        if (hasProgress == null)
        {
            Debug.LogError("Game Object " + hasProgressGameObject + " does not have a component that implements IHasProgress");
            return;
        }
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        barImage.fillAmount = 0f;
        barImage.color = Color.blue;
        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (lavadora != null && lavadora.IsWashed())
        {
            barImage.color = Color.red;
        }
        else
        {
            barImage.color = new Color(0.2f, 0.6f, 1f); // Azul claro para lavar
        }

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