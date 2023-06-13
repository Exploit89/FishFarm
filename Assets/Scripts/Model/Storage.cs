using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _capacity;
    private int _freeCapacity;
    private string _name;
    private List<Product> _products;

    private void CapturePlace(int value)
    {
        _freeCapacity -= value;
    }

    private void FreePlace(int value)
    {
        _freeCapacity += value;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }

    public void AddProductCount(Product product)
    {
        foreach (var item in _products)
        {
            if(item.ProductType == product.ProductType)
            {
                // TODO количество увеличить
            }
        }
    }
}
