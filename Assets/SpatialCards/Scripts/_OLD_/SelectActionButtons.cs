#if false
using MixedReality.Toolkit.Editor;
using MixedReality.Toolkit.UX;
using UnityEngine;

public class SelectActionButtons : MonoBehaviour
{
    public PressableButton RemoveButton;
    public PressableButton CopyButton;

    private void SubscribeEvents()
    {
        RemoveButton.onentered
    }

    public enum SelectActionType { None, Remove, Copy }

    private bool isChangingCurrentAction;
    public void SetCurrentAction(SelectActionType type)
    {
        if (isChangingCurrentAction == true) return; //To avoid recursion
        isChangingCurrentAction = true;

        RemoveButton.ForceSetToggled(type == SelectActionType.Remove);
        CopyButton.ForceSetToggled(type == SelectActionType.Copy);

        CardManager.CardSelectedAction = type switch
        {
            SelectActionType.Remove => RemoveCard,
            SelectActionType.Copy => CopyCard,
            _ => null
        };
        isChangingCurrentAction = false;
    }

    public void StartRemoveAction() => SetCurrentAction(SelectActionType.Remove);
    public void StartCopyAction() => SetCurrentAction(SelectActionType.Copy);
    public void StopAction() => SetCurrentAction(SelectActionType.None);

    private void RemoveCard(Card card)
    {
        CardManager.DestroyCard(card);
        SetCurrentAction(SelectActionType.None);
    }

    private void CopyCard(Card card)
    {
        Debug.Log("TODO: Clone card");
        SetCurrentAction(SelectActionType.None);
    }
}
#endif