using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _gameObject;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _label;

    private int _fillValue = 0;
    private float _relativeFillValue = 0;
    private int _maxValue = 0;

    public float TweenerSpeed { get; private set; } = 2f;

    public event UnityAction<TweenerCore<float, float, FloatOptions>> TweenStarted;

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
            DOTween.To(ShowLabel, _fillValue, value, TweenerSpeed);
            _relativeFillValue = value / (float)_maxValue;
            var tween = _image.DOFillAmount(_relativeFillValue, TweenerSpeed);
            TweenStarted?.Invoke(tween);
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

    public float GetFillAmount()
    {
        return _image.fillAmount;
    }
}
