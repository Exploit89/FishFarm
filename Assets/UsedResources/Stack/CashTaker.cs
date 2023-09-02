using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wallet))]

public class CashTaker : MonoBehaviour
{
    [SerializeField] private List<ProductType> _productTypes;

    private Wallet _wallet;

    public bool CanTakeCash { get; private set; } = false;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
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

    public void SetTakeable(bool flag)
    {
        CanTakeCash = flag;
    }
}
