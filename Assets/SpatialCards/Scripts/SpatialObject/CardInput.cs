using MixedReality.Toolkit.UX;
using UnityEngine;
using UnityEngine.Events;

public class CardInput : MonoBehaviour
{
    public MRTKTMPInputField InputField;
    public PressableButton EditButton;

    public bool IsEditing { get; private set; }

    public UnityEvent<string> OnTextEditingFinished;

    public void StartTextEdit()
    {
        if (IsEditing == true) return;
        IsEditing = true;

        Keyboard.StartEditing(InputField, onClose: StopTextEdit);
        EditButton.ForceSetToggled(true);
    }

    public void StopTextEdit()
    {
        if (IsEditing == false) return;
        IsEditing = false;

        Keyboard.StopEditing();
        EditButton.ForceSetToggled(false);
        OnTextEditingFinished?.Invoke(InputField.text);
    }
}
