using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashTime = 0.2f;

    public void Flash()
    {
        gameObject.SetActive(true);
        flashImage.color = new Color(1, 0, 0, 0.1f); // vermelho semitransparente
        CancelInvoke();
        Invoke(nameof(Hide), flashTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}