using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _gameObject;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _label;

    private int _fillValue = 0;
    private float _relativeFillValue = 0;
    private int _maxValue = 0;
    private float _tweenerSpeed = 2f;

    private void Start()
    {
        _maxValue = _wallet.GetMaxValue();
        UpdateFillValue(_fillValue);
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
        if(value != 0)
        {
            DOTween.To(ShowLabel, _fillValue, value, _tweenerSpeed);
            _relativeFillValue = value / (float)_maxValue;
            _image.DOFillAmount(_relativeFillValue, _tweenerSpeed);
            _fillValue = value;
        }
        else
        {
            ShowLabel(_fillValue);
            _image.fillAmount = _fillValue;
        }
    }

    private void ShowLabel(float value)
    {
        if (_maxValue != 0)
            _label.text = Mathf.Round(value) + "/" + _maxValue.ToString();
        else
            _label.text = "";
    }
}
