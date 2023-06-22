using UnityEngine;

public class IShop : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    public Wallet GetWallet()
    {
        Wallet wallet = new Wallet();
        wallet = _wallet;
        return wallet;
    }

    public void SetFixedPrice(int value)
    {
        _wallet.SetFixedPrice(value);
    }
}
