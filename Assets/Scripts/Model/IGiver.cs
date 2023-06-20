using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StackMover))]

public class IGiver : MonoBehaviour
{
    [SerializeField] private List<ProductType> _productTypes;

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
}
