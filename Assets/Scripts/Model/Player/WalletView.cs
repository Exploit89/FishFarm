using UnityEngine;
using TMPro;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private Wallet _wallet;
    private int _ViewChangeCount = 100;
    private int _randomMin = 0;
    private int _randomMax = 100000;

    private void Start()
    {
        _player.WalletCreated += SubscribeOnWallet;
    }

    private void OnEnable()
    {
        _player.WalletCreated += SubscribeOnWallet;
        if (_wallet != null)
            _wallet.OnValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _player.WalletCreated -= SubscribeOnWallet;
        if (_wallet != null)
            _wallet.OnValueChanged -= UpdateValue;
    }

    private void UpdateValue(int value)
    {
        for (int i = 0; i < _ViewChangeCount; i++)
        {
            int random = Random.Range(_randomMin, _randomMax);
            _text.text = random.ToString();
        }
        _text.text = _wallet.Value.ToString();
        Debug.Log("on update" + _wallet.Value);
    }

    private void SubscribeOnWallet(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.OnValueChanged += UpdateValue;
        UpdateValue(wallet.Value);
        Debug.Log("on subscribe" + wallet.Value);
    }
}
