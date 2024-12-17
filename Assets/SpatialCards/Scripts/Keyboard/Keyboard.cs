using System;
using TMPro;
using UnityEngine;

public abstract class Keyboard
{
    private static readonly Keyboard Provider;

    static Keyboard()
    {
        Provider = TouchScreenKeyboard.isSupported ?
            new NativeKeyboard() :
            new StandardKeyboard();
    }

    public static bool Editing { get; private set; }

    public static TMP_InputField Target { get; private set; }
    public static Action OnClose { get; private set; }

    public static void StartEditing(TMP_InputField target, Action onClose = null)
    {
        if (Editing == true)
        {
            StopEditing();
        }
        Editing = true;

        Provider.EditingStarted(target, onClose);
        Target = target;
        OnClose = onClose;
    }

    public static void StopEditing()
    {
        if (Editing == false) return;
        Editing = false;

        OnClose?.Invoke();
        Provider.EditingStopped();
        Target = null;
        OnClose = null;
    }

    protected abstract void EditingStarted(TMP_InputField target, Action onClose);
    protected abstract void EditingStopped();
}
