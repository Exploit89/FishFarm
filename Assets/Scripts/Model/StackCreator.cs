using System;
using System.Collections.Generic;
using UnityEngine;

public class StackCreator : MonoBehaviour
{
    [SerializeField] private Product _productPrefab;

    private int _startQuantity = 10;

    private Stack Initialize(Product product, int quantity)
    {
        Stack stack = new Stack(product, quantity);
        Debug.Log("Stack initialized = " + product + quantity);
        return stack;
    }

    public List<Stack> CreateStacks()
    {
        List<Stack> stacks = new List<Stack>();

        foreach (ProductType productType in Enum.GetValues(typeof(ProductType)))
        {
            Product product = Instantiate(_productPrefab, transform);
            product.SetProductType(productType);
            Debug.Log("product = " + product);
            Stack stack = Initialize(product, _startQuantity);
            stacks.Add(stack);
            Debug.Log("Stacks created = " + stack.Product + stack.Quantity);
        }
        return stacks;
    }
}
