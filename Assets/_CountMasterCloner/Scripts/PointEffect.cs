using UnityEngine;
using TMPro;
using DG.Tweening;

public class PointEffect : MonoBehaviour
{
    public float endY;
    public float duration;
    public TMP_Text pointText;

    private void Start()
    {
        transform.DOMoveY(endY, duration)
            .OnComplete(() => Destroy(gameObject));
    }
}