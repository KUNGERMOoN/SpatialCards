/*using UnityEngine;

[RequireComponent(typeof(CardInput))]
public class SpatialCard : SpatialObject<SpatialCardState>
{
    public CardInput CardInput;

    SpatialCardState state = new("");
    public override SpatialCardState State
    {
        get => state;
        set
        {
            state = value;
            CardInput.InputField.text = state.Text;
        }
    }

    private void OnEnable()
    {
        CardInput.OnTextEdited += UpdateState;
    }

    private void OnDisable()
    {
        CardInput.OnTextEdited -= UpdateState;
    }

    private void UpdateState(string newText)
        => State = new(newText);
}
*/