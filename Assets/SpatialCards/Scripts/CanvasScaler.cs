using UnityEngine;

public class CanvasScaler : MonoBehaviour
{
    public Transform ScaledObject;

    RectTransform rectTransform;

    Vector2 originalScale;
    Vector3 originalLocalScale;
    Vector2 originalSize;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        originalScale = ScaledObject.localScale;
        originalLocalScale = rectTransform.localScale;
        originalSize = rectTransform.sizeDelta;
    }

    private void Update()
    {
        Vector2 scaleRatio = ScaledObject.localScale / originalScale;
        rectTransform.sizeDelta = originalSize * scaleRatio;

        rectTransform.localScale = new Vector3(
            originalLocalScale.x / scaleRatio.x,
            originalLocalScale.y / scaleRatio.y,
            originalLocalScale.z);
    }
}
