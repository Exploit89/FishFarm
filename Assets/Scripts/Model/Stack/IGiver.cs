using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Wallet))]

public class IGiver : MonoBehaviour
{
    [SerializeField] private List<ProductType> _productTypes;

    private Wallet _wallet;
    private int _maxCash;

    public bool CanGiveCash { get; private set; } = false;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _wallet.SetMaxCash(_maxCash);
    }

    public void AddProductType(ProductType productType)
    {
        _productTypes.Add(productType);
    }

    public List<ProductType> GetProductTypes()
    {
        List<ProductType> products = new List<ProductType>();
        products = _productTypes;
        return products;
    }

    public void SetGiveable(bool flag)
    {
        CanGiveCash = flag;
    }
}
