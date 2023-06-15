using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Capacity))]

public class StackMover : MonoBehaviour
{
    private List<Stack> _products;
    private int _freeCapacity = 0;

    private void Start()
    {
        _freeCapacity = GetComponent<Capacity>().FreeCapacity;
    }

    private void ClearStacks()
    {
        if (_products != null)
        {
            _products.Clear();
            Debug.Log("Stacks cleared - " + _products + _products.Count);
        }
    }

    private int GetPossibleQuantity(int spaceToCapture)
    {
        int possibleSpace = 0;
        int neededSpace = _freeCapacity - spaceToCapture;

        if (neededSpace < 0)
        {
            possibleSpace = spaceToCapture + neededSpace;
            _freeCapacity = 0;
            return possibleSpace;
        }
        _freeCapacity -= spaceToCapture;
        return spaceToCapture;
    }

    public void CreateStacks()
    {
        ClearStacks();
        Stack stack = new Stack();
        _products = stack.CreateStacks();
        Debug.Log("Stacks created - " + _products + _products.Count);
    }

    public void AddProductCount(Stack stack)
    {
        foreach (var item in _products)
        {
            if (item.Product.ProductType == stack.Product.ProductType)
            {
                Debug.Log("Storage stack qty before add = " + item.Quantity);
                item.IncreaseQuantity(GetPossibleQuantity(stack.Quantity));
                Debug.Log("Storage stack qty after add = " + item.Quantity);
            }
        }
    }
}
