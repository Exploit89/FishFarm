using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StackMover))]

public class ITaker : MonoBehaviour
{
    [SerializeField] private List<ProductType> _productTypes;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
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

    public Wallet GetWallet()
    {
        Wallet wallet = new Wallet();
        wallet = _wallet;
        return wallet;
    }
}
