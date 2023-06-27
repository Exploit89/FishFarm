using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class CashExchanger : MonoBehaviour
{
    private Wallet _wallet;
    private int _changedValue = 0;

    public event UnityAction<Item> ItemBought;

    private void OnEnable()
    {
        GetComponent<Player>().WalletCreated += SubscribeOnWallet;
        if (_wallet != null)
            _wallet.OnValueChanged += SetChangedValue;
    }

    private void OnDisable()
    {
        GetComponent<Player>().WalletCreated -= SubscribeOnWallet;
        if (_wallet != null)
            _wallet.OnValueChanged -= SetChangedValue;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ITaker iTaker))
        {
            Wallet otherWallet = collider.GetComponent<Wallet>();
            TryGive(otherWallet);
        }

        if (collider.TryGetComponent(out IGiver iGiver))
        {
            Wallet otherWallet = collider.GetComponent<Wallet>();
            TryTake(otherWallet);
        }

        if(collider.TryGetComponent(out Shop shop))
        {
            // TODO ������� ����� ������ ��������
        }
    }

    private void SubscribeOnWallet(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.OnValueChanged += SetChangedValue;
    }

    private void TryTake(Wallet wallet)
    {
        _wallet.AddValue(wallet.Value);
        wallet.RemoveValue(wallet.Value);
    }

    private void TryGive(Wallet wallet)
    {
        wallet.AddValue(_wallet.Value);
        _wallet.RemoveValue(_changedValue);
    }

    private void SetChangedValue(int value)
    {
        _changedValue = value;
    }

    public void TryShopBuy(Item item)
    {
        if (_wallet.CanBuy(item.Price))
        {
            _wallet.RemoveFixedValue(item.Price);
            ItemBought?.Invoke(item);
        }
    }
}
