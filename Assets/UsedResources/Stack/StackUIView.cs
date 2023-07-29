using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Image _icon;

    private AAAStack _stack;
    private int _lastValue;
    private int _value;
    private float _tweenerSpeed = 1f;
    private bool _isChanged = false;

    private void ShowLabel(float value)
    {
        _count.text = Mathf.Round(value).ToString();
    }

    public void Render(AAAStack stack)
    {
        _stack = stack;
        _label.text = _stack.Label;
        _icon.sprite = _stack.Image;

        if (int.TryParse(_count.text, System.Globalization.NumberStyles.Integer, null, out int value))
            _value = value;
        _lastValue = value;
        DOTween.To(ShowLabel, _value, _stack.Quantity, _tweenerSpeed);

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
