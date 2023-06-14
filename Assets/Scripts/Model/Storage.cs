using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _capacity;
    private int _freeCapacity;
    private string _name;
    private List<Stack> _products;
    private Factory _factory; //

    private void OnEnable()
    {
        GameObject equipment = gameObject.GetComponentInParent<GameObject>(); //
        _factory = equipment.GetComponentInChildren<Factory>(); //
    }

    private void OnDisable()
    {
        
    }

    private void CapturePlace(int value)
    {
        _freeCapacity -= value;
    }

    private void FreePlace(int value)
    {
        _freeCapacity += value;
    }

    public void AddProduct(Stack stack)
    {
        _products.Add(stack);
    }

    public void RemoveProduct(Stack stack)
    {
        _products.Remove(stack);
    }

    public void TryAddProductCount()
    {
        int totalCount = 0;

        foreach (var item in _products)
        {
            totalCount += item.Quantity;
        }
    }

    public void AddProductCount(Stack stack)
    {
        foreach (var item in _products)
        {
            if(item.Product.ProductType == stack.Product.ProductType)
            {
                _products.Add(item);
            }
        }
    }
}
