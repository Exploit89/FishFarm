using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class CashExchanger : MonoBehaviour
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private GameObject _shop;

    private int _changedValue = 0;

    public event UnityAction<Item> ItemBought;
    public event UnityAction<GameObject> ShopEntered;
    public event UnityAction NotEnoughCash;

    private void OnEnable()
    {
        _playerWallet.OnValueChanged += SetChangedValue;
    }

    private void OnDisable()
    {
        _playerWallet.OnValueChanged -= SetChangedValue;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out CashTaker iTaker) && iTaker.CanTakeCash)
        {
            Wallet otherWallet = collider.GetComponent<Wallet>();
            TryGive(otherWallet);
        }

        if (collider.TryGetComponent(out CashGiver iGiver) && iGiver.CanGiveCash)
        {
            Wallet otherWallet = collider.GetComponent<Wallet>();
            TryTake(otherWallet);
        }

        if(collider.TryGetComponent(out ShopBuilding shop))
        {
            ShopEntered?.Invoke(_shop);
        }
    }

    private void TryTake(Wallet wallet)
    {
        _playerWallet.AddValue(wallet.Value);
        wallet.RemoveValue(wallet.Value);
    }

    private void TryGive(Wallet wallet)
    {
        int newValue = wallet.AddValue(_playerWallet.Value);
        _playerWallet.RemoveValue(newValue);
    }

    private void SetChangedValue(int value)
    {
        _changedValue = value;
    }

    public void TryShopBuy(Item item)
    {
        if (_playerWallet.CanBuy(item.Price))
        {
            _playerWallet.RemoveFixedValue(item.Price);
            ItemBought?.Invoke(item);
        }
        else
        {
            NotEnoughCash?.Invoke();
        }
    }
}
