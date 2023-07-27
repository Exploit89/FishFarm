using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Image _icon;

    private Stack _stack;
    private int _lastValue;
    private int _value;
    private float _tweenerSpeed = 1f;
    private bool _isChanged = false;

    private void ShowLabel(float value)
    {
        _count.text = Mathf.Round(value).ToString();
    }

    private void RenderStackView(Stack stack)
    {
        Transform stackItemTransform = transform;

        for (int i = 0; i < stack.Quantity; i++)
        {
            var stackItem = Instantiate(stack, stackItemTransform);
            stackItem.transform.position += new Vector3(2, 2, 0);
            stackItemTransform = stackItem.transform;
        }
    }

    public void Render(Stack stack)
    {
        _stack = stack;
        _label.text = _stack.Label;
        _icon.sprite = _stack.Icon;

        if (int.TryParse(_count.text, System.Globalization.NumberStyles.Integer, null, out int value))
            _value = value;
        _lastValue = value;
        DOTween.To(ShowLabel, _value, _stack.Quantity, _tweenerSpeed);
        RenderStackView(stack);

        if (_value == _stack.Quantity)
            _isChanged = false;
        else _isChanged = true;
        _value = _stack.Quantity;
        _count.text = _stack.Quantity.ToString();
    }

    public int GetValue()
    {
        return _value;
    }

    public float GetTweenerSpeed()
    {
        return _tweenerSpeed;
    }

    public int GetLastValue()
    {
        return _lastValue;
    }

    public bool IsChanged()
    {
        return _isChanged;
    }
}
