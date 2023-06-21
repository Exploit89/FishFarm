using UnityEngine;

[RequireComponent(typeof(Player))]

public class CashExchanger : MonoBehaviour
{
    private Wallet _wallet;
    private int _changedValue = 0;

    private void Awake()
    {
        _wallet = GetComponent<Player>().GetWallet();
    }

    private void OnEnable()
    {
        _wallet.OnValueChanged += SetChangedValue;
    }

    private void OnDisable()
    {
        _wallet.OnValueChanged -= SetChangedValue;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Wallet wallet))
            wallet.OnValueChanged += SetChangedValue;

        if (collider.TryGetComponent(out ITaker iTaker))
        {
            Wallet otherWallet = collider.GetComponent<ITaker>().GetWallet();
            TryGive(otherWallet);
        }

        if (collider.TryGetComponent(out IGiver iGiver))
        {
            Wallet otherWallet = collider.GetComponent<IGiver>().GetWallet();
            TryTake(otherWallet);
        }

        if(collider.TryGetComponent(out IShop iShop))
        {
            Wallet otherWallet = collider.GetComponent<IGiver>().GetWallet();
            TryBuy(otherWallet);
        }
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

    private void TryBuy(Wallet wallet)
    {
        if(_wallet.CanBuy(wallet.FixedPrice))
            _wallet.RemoveFixedValue(wallet.FixedPrice);
    }

    private void SetChangedValue(int value)
    {
        _changedValue = value;
    }
}
