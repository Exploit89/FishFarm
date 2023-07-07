using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Image _icon;

    private Stack _stack;
    private int _value;
    private float _tweenerSpeed = 1f;

    private void ShowLabel(float value)
    {
        _count.text = Mathf.Round(value).ToString();
    }

    public void Render(Stack stack)
    {
        _stack = stack;
        _label.text = _stack.Label;
        _icon.sprite = _stack.Icon;

        if (int.TryParse(_count.text, System.Globalization.NumberStyles.Integer, null, out int value))
            _value = value;
        DOTween.To(ShowLabel, _value, _stack.Quantity, _tweenerSpeed);
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
}
