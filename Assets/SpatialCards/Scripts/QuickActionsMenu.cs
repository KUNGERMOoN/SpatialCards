using UnityEngine;

public class QuickActionsMenu : MonoBehaviour
{
    public Transform Camera;
    public SpatialObjectOptions Options;

    [Space]
    public float AddObjectOffset;
    public float CloneObjectOffset;

    public void AddCard()
    {
        var position = Camera.position + Camera.forward * AddObjectOffset;
        var rotation = Quaternion.Euler(0, Camera.eulerAngles.y, 0);
        CreateSpatialObject(position, rotation);
    }

    public void DeleteObjects()
    {
        foreach (var selectable in SelectableObject.SelectedObjects)
            selectable.SpatialObject.Destroy();
    }

    public void CloneObjects()
    {
        foreach (var selectable in SelectableObject.SelectedObjects)
        {
            var transform = selectable.transform;
            var position = transform.position - CloneObjectOffset * transform.forward;
            CreateSpatialObject(position, transform.rotation, selectable);
        }
        SelectableObject.DeselectAll();
    }

    SpatialObject CreateSpatialObject(Vector3 position, Quaternion rotation, SelectableObject source = null)
    {
        SpatialObject newObject;
        if (source != null)
            newObject = source.SpatialObject.Clone();
        else
            newObject = Instantiate(Options.CardPrefab);

        newObject.transform.SetPositionAndRotation(position, rotation);
        return newObject;
    }

    public void DeselectObjects() => SelectableObject.DeselectAll();
}
