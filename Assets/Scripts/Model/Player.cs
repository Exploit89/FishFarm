using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private List<Stack> _products = new List<Stack>();

    private void Start()
    {
        _wallet = new Wallet();
        CreateStacks();
    }

    private void CreateStacks()
    {
        ClearStacks();
        Product product = new Product();
        Stack stack = new Stack();

        foreach (ProductType productType in Enum.GetValues(typeof(ProductType)))
        {
            product.SetProductType(productType);
            stack.Initialize(product, 0);
            _products.Add(stack);
        }
    }

    private void ClearStacks()
    {
        _products.Clear();
    }
}
