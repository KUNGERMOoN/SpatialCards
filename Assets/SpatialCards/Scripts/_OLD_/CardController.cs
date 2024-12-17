#if false
using UnityEngine;

[RequireComponent(typeof(SpatialObject))]
public abstract class CardController : MonoBehaviour
{
    public SpatialObject Card { get; private set; }

    protected virtual void Awake()
        => Card = GetComponent<SpatialObject>();
}
#endif