using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Image _icon;

    private Stack _stack;

    public void Render(Stack stack)
    {
        _stack = stack;
        _label.text = _stack.Label;
        _icon.sprite = _stack.Icon;
        _count.text = _stack.Quantity.ToString();
    }
}
