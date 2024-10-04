using System;
using TMPro;

public class NativeKeyboard : Keyboard
{
    protected override void EditingStarted(TMP_InputField target, Action onClose)
    {
        NativeKeyboardProvider.Open(target.text, OnTextChanged, onClosed: StopEditing);
    }

    protected override void EditingStopped()
    {
        NativeKeyboardProvider.Close();
    }

    void OnTextChanged(string text)
        => Target.text = text;
}
