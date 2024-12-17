using MixedReality.Toolkit.UX.Experimental;
using System;
using TMPro;

internal class StandardKeyboard : Keyboard
{
    private NonNativeKeyboard Keyboard => NonNativeKeyboard.Instance;

    protected override void EditingStarted(TMP_InputField target, Action _)
    {
        if (!Keyboard.gameObject.activeInHierarchy)
        {
            Keyboard.OnClose.AddListener(OnKeyboardClose);
            Keyboard.OnTextUpdate.AddListener(OnUpdateInputField);
            Keyboard.Open();
        }

        Keyboard.Text = target.text;
        for (int i = Keyboard.CaretIndex; i < target.text.Length; i++)
            Keyboard.MoveCaretRight();
    }

    protected override void EditingStopped()
    {
        if (Keyboard.gameObject.activeInHierarchy)
        {
            Keyboard.OnClose.RemoveListener(OnKeyboardClose);
            Keyboard.OnTextUpdate.RemoveListener(OnUpdateInputField);
            Keyboard.Close();
        }
    }

    private void OnUpdateInputField(string text)
    {
        if (Target != null)
            Target.text = text;
    }

    private void OnKeyboardClose(string text)
    {
        StopEditing();
    }
}
