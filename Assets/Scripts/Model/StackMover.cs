using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Capacity))]
[RequireComponent(typeof(StackCreator))]

public class StackMover : MonoBehaviour
{
    private StackCreator _stackCreator;
    private List<Stack> _products;
    private int _freeCapacity = 100;

    public event UnityAction<int> OnStackChanged;

    private void Awake()
    {
        _stackCreator = GetComponent<StackCreator>();
    }

    private void Start()
    {
        _products = new List<Stack>();
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
        _products = _stackCreator.CreateStacks();
        Debug.Log("Stacks created - " + _products + _products.Count);
    }

    public void AddProductCount(Stack stack)
    {
        foreach (var item in _products)
        {
            if (item.Product.ProductType == stack.Product.ProductType)
            {
                Debug.Log("Storage stack qty before add = " + item.Quantity);
                int possibleQuantity = GetPossibleQuantity(stack.Quantity);
                item.IncreaseQuantity(possibleQuantity);
                Debug.Log("Storage stack qty after add = " + item.Quantity);
                OnStackChanged?.Invoke(possibleQuantity);
            }
        }
    }

    public void RemoveProductCount(Stack stack)
    {
        foreach (var item in _products)
        {
            if (item.Product.ProductType == stack.Product.ProductType)
            {
                Debug.Log("Storage stack qty before remove = " + item.Quantity);
                Debug.Log("Free capacity before remove = " + item.Quantity);
                item.DecreaseQuantity(stack.Quantity);
                _freeCapacity += stack.Quantity;
                Debug.Log("Storage stack qty after remove = " + item.Quantity);
                Debug.Log("Free capacity after remove = " + item.Quantity);
                OnStackChanged?.Invoke(stack.Quantity);
            }
        }
    }

    public void RemoveProductCount(Stack stack, int value)
    {
        foreach (var item in _products)
        {
            if (item.Product.ProductType == stack.Product.ProductType)
            {
                Debug.Log("Storage stack qty before remove = " + value);
                Debug.Log("Free capacity before remove = " + value);
                item.DecreaseQuantity(value);
                _freeCapacity += value;
                Debug.Log("Storage stack qty after remove = " + value);
                Debug.Log("Free capacity after remove = " + value);
                OnStackChanged?.Invoke(value);
            }
        }
    }

    public List<Stack> GetStacks()
    {
        List<Stack> list = new List<Stack>();
        list = _products;
        return list;
    }
}
