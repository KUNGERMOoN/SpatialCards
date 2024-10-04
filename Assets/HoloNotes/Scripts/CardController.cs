using MixedReality.Toolkit.UX;
using MixedReality.Toolkit.UX.Experimental;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public MRTKTMPInputField InputField;
    public PressableButton EditButton;

    public void StartTextEdit()
    {
        SetEditButton(true);
        Keyboard.StartEditing(InputField, onClose: StopTextEdit);
    }

    public void StopTextEdit()
    {
        Keyboard.StopEditing();
        SetEditButton(false);
    }

    private void SetEditButton(bool toggled)
    {
        if (EditButton.IsToggled != toggled)
            EditButton.ForceSetToggled(toggled, fireEvents: true);
    }
}
