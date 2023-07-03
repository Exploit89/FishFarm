using UnityEngine;
using TMPro;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        UpdateValue(_playerWallet.Value);
        _playerWallet.OnValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _playerWallet.OnValueChanged -= UpdateValue;
    }

    private void UpdateValue(int value)
    {
        _text.text = value.ToString();
    }
}
