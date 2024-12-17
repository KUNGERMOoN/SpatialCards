using System;
using System.Collections;
using UnityEngine;

public class SpatialObjectAnimator : MonoBehaviour
{
    private Coroutine animationCoroutine;
    private Action onAnimationCompleted;

    public void AnimateCard(AnimationCurve scaleAnimation, float animationLength, Action onCompleted = null)
    {
        if (animationCoroutine != null) AnimationCompleted();

        animationCoroutine = StartCoroutine(CardAnimationCoroutine(scaleAnimation, animationLength));
        onAnimationCompleted = onCompleted;
    }

    private IEnumerator CardAnimationCoroutine(AnimationCurve scaleAnimation, float animationLength)
    {
        Vector3 initialScale = transform.localScale;
        float endValue = scaleAnimation.Evaluate(1);
        Vector3 targetScale = new(endValue, endValue, endValue);

        float endTime = Time.time + animationLength;
        while (Time.time <= endTime)
        {
            var progress = (endTime - Time.time) / animationLength;

            transform.localScale = Vector3.Lerp(initialScale, targetScale,
                scaleAnimation.Evaluate(progress));

            yield return null;
        }
        AnimationCompleted();
    }

    private void AnimationCompleted()
    {
        animationCoroutine = null;
        onAnimationCompleted?.Invoke();
    }
}
