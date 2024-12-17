using System;
using UnityEngine;

public class NativeKeyboardProvider : MonoBehaviour
{
    private static TouchScreenKeyboard keyboard;
    private static Action<string> onTextChanged;
    private static Action onClosed;

    private static string text;
    private static bool wasActive;

    public static void Open(string text, Action<string> onTextChanged, Action onClosed)
    {
        if (keyboard == null)
        {
            keyboard = TouchScreenKeyboard.Open(text, TouchScreenKeyboardType.Default,
                false, multiline: true, false, false);
        }
        else
        {
            keyboard.active = true;
            keyboard.text = text;
        }

        NativeKeyboardProvider.onTextChanged = onTextChanged;
        NativeKeyboardProvider.onClosed = onClosed;
    }

    public static void Close()
    {
        if (keyboard != null)
            keyboard.active = false;

        wasActive = false;
        onTextChanged = null;
        onClosed = null;
    }

    void Update()
    {
        if (keyboard?.text != text)
        {
            onTextChanged?.Invoke(text);
            text = keyboard?.text;
        }

        bool isActive = keyboard?.active ?? false;
        if (wasActive && !isActive)
        {
            onClosed?.Invoke();
        }
        wasActive = isActive;
    }
}
