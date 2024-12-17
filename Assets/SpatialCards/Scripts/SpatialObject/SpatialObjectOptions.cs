using UnityEngine;

[CreateAssetMenu(menuName = "Spatial Cards/Spatial Object Options", fileName = "Spatial Object Options")]
public class SpatialObjectOptions : ScriptableObject
{
    [Header("References")]
    public SpatialCard CardPrefab;

    public AnimationCurve AddAnimation;
    public AnimationCurve RemoveAnimation;
    public float AnimationDuration;
}
