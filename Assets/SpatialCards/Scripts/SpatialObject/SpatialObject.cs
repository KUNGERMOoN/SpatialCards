using MixedReality.Toolkit.SpatialManipulation;
using UnityEngine;

public abstract class SpatialObject : MonoBehaviour
{
    public SpatialObjectOptions Options;
    public BoundsControl BoundsControl;

    public SpatialObjectAnimator Animator
    { get; private set; }

    protected virtual void Awake()
    {
        Animator = GetComponent<SpatialObjectAnimator>();
        Animator.AnimateCard(Options.AddAnimation, Options.AnimationDuration);
    }

    public void Destroy()
    {
        BoundsControl.HandlesActive = false;
        Animator.AnimateCard(Options.RemoveAnimation, Options.AnimationDuration, onCompleted: () =>
        {
            Destroy(gameObject);
        });
    }

    public abstract SpatialObject Clone();
}
