using System;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public void Initialize(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int value)
    {
        Quantity += value;
    }

    public void DecreaseQuantity(int value)
    {
        Quantity -= value;
    }

    //private void CreateStacks()
    //{
    //    ClearStacks();
    //    Product product = new Product();
    //    Stack stack = new Stack();

    //    foreach (ProductType productType in Enum.GetValues(typeof(ProductType)))
    //    {
    //        product.SetProductType(productType);
    //        stack.Initialize(product, 0);
    //        _products.Add(stack);
    //    }
    //}

    //private void ClearStacks()
    //{
    //    _products.Clear();
    //}
}
