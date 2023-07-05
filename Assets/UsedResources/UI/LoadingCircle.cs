using UnityEngine;
using UnityEngine.UI;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _gameObject;
    [SerializeField] private Wallet _wallet;

    private int _fillValue = 0;
    private int _maxValue = 0;

    private void Start()
    {
        _maxValue = _wallet.GetMaxValue();
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
        Debug.Log(_maxValue);
        Debug.Log(value);
        _image.fillAmount = value / _maxValue;
    }
}
