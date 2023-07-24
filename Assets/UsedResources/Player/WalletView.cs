using UnityEngine;
using TMPro;
using DG.Tweening;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private TMP_Text _text;

    private int _value;

    private void OnEnable()
    {
        _value = _playerWallet.Value;
        UpdateValue(_value);
        _playerWallet.OnValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _playerWallet.OnValueChanged -= UpdateValue;
    }

    private void UpdateValue(int value = 0)
    {
        DOTween.To(ShowLabel, _value, value, 2f);
        _value = value;
    }

    private void ShowLabel(float value)
    {
        _text.text = Mathf.Round(value).ToString();
    }
}
