using UnityEngine;
using UnityEngine.Events;

public class SpatialCard : SpatialObject
{
    [SerializeField, Space]
    private string text;
    private string lastText;
    public string Text
    {
        get => text;
        set
        {
            text = value;
            if (text != lastText)
            {
                OnTextChanged?.Invoke(text);
                lastText = text;
            }
        }
    }

    [Space]
    public UnityEvent<string> OnTextChanged;

    private void OnValidate()
    {
        Text = text;
    }

    public SpatialObject SpatialObject { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        SpatialObject = GetComponent<SpatialObject>();
    }

    public override SpatialObject Clone()
    {
        var card = Instantiate(SpatialObject.Options.CardPrefab);
        card.Text = Text;
        return card;
    }
}