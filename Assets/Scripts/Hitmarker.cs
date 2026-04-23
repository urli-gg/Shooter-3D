using UnityEngine;
using UnityEngine.UI;

public class Hitmarker : MonoBehaviour
{
    public Image hitImage;
    public float duration = 0.1f;

    public void ShowHitmarker()
    {
        StopAllCoroutines();
        StartCoroutine(Hit());
    }

    System.Collections.IEnumerator Hit()
    {
        hitImage.enabled = true;
        yield return new WaitForSeconds(duration);
        hitImage.enabled = false;
    }
}
