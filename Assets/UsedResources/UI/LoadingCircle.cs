using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _gameObject;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _label;

    private int _fillValue = 0;
    private int _maxValue = 0;

    private void Start()
    {
        _maxValue = _wallet.GetMaxValue();
        _label.text = _fillValue.ToString() + "/" + _maxValue.ToString();
        _image.fillAmount = _fillValue;
    }

    private void OnEnable()
    {
        _wallet.OnValueChanged += UpdateFillValue;
    }

    private void OnDisable()
    {
        _wallet.OnValueChanged -= UpdateFillValue;
    }

    private void UpdateFillValue(int value)
    {
        float currentValue = value / (float)_maxValue;
        _image.fillAmount = currentValue;
        _label.text = value.ToString() + "/" + _maxValue.ToString();
    }
}
