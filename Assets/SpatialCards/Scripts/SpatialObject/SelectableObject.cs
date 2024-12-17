using MixedReality.Toolkit.SpatialManipulation;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectableObject : MonoBehaviour
{
    public SpatialObject SpatialObject;
    public ObjectManipulator Manipulator;

    [Space]
    public float DragSelectTreshold = 0.02f;
    public UnityEvent OnSelected;
    public UnityEvent OnDeselected;

    public bool IsDragged { get; private set; }

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (isSelected == value) return;
            isSelected = value;

            if (isSelected)
            {
                OnSelected?.Invoke();
                selectedObjects.Add(this);
            }
            else
            {
                OnDeselected?.Invoke();
                selectedObjects.Remove(this);
            }
        }
    }
    private bool isSelected;

    public static IReadOnlyList<SelectableObject> SelectedObjects => selectedObjects;
    private readonly static List<SelectableObject> selectedObjects = new();

    public static void DeselectAll()
    {
        foreach (var @object in new List<SelectableObject>(SelectedObjects))
            @object.IsSelected = false;
    }

    private void Awake()
    {
        Manipulator.firstSelectEntered.AddListener(OnSelect);
        Manipulator.lastSelectExited.AddListener(OnDeselect);
    }

    private void OnDestroy()
    {
        IsSelected = false;

        Manipulator.firstSelectEntered.RemoveListener(OnSelect);
        Manipulator.lastSelectExited.RemoveListener(OnDeselect);
    }

    private Vector3 dragStartPosition;
    private bool draggedTooFarToSelect;
    private void OnSelect(SelectEnterEventArgs args)
    {
        IsDragged = true;
        dragStartPosition = transform.position;
        draggedTooFarToSelect = false;
    }

    private void Update()
    {
        if (Vector3.Distance(dragStartPosition, transform.position) > DragSelectTreshold)
            draggedTooFarToSelect = true;
    }

    private void OnDeselect(SelectExitEventArgs args)
    {
        IsDragged = false;

        if (!draggedTooFarToSelect)
            IsSelected = !IsSelected;
    }
}
