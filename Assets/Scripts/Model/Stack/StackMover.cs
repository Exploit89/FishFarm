using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Capacity))]
[RequireComponent(typeof(StackCreator))]

public class StackMover : MonoBehaviour
{
    [SerializeField] private List<Stack> _products;

    private StackCreator _stackCreator;
    private int _freeCapacity = 0;

    public event UnityAction<int> OnStackChanged;

    private void Awake()
    {
        _products = new List<Stack>();
        _stackCreator = GetComponent<StackCreator>();
    }

    private void Start()
    {
        _freeCapacity = GetComponent<Capacity>().FreeCapacity;
    }

    private void ClearStacks()
    {
        if (_products != null)
            _products.Clear();
    }

    private int GetPossibleQuantity(int spaceToCapture)
    {
        int possibleSpace = 0;
        int neededSpace = _freeCapacity - spaceToCapture;
        Debug.Log("needed space = " + neededSpace);

        if (neededSpace < 0)
        {
            possibleSpace = spaceToCapture + neededSpace;
            _freeCapacity = 0;
            Debug.Log("returned possible = " + possibleSpace);
            return possibleSpace;
        }
        _freeCapacity -= spaceToCapture;
        return spaceToCapture;
    }

    public void CreateStacks(int value)
    {
        ClearStacks();
        _products = _stackCreator.CreateStacks(value);
    }

    public void AddProductCount(Stack stack)
    {
        foreach (var item in _products)
        {
            if (item.Product.ProductType == stack.Product.ProductType)
            {
                int possibleQuantity = GetPossibleQuantity(stack.Quantity);

                if(possibleQuantity > item.GetMaxQuantity())
                {
                    Debug.Log("possible qty = " + possibleQuantity);
                    OnStackChanged?.Invoke(possibleQuantity);
                    item.IncreaseQuantity(possibleQuantity);
                }
                OnStackChanged?.Invoke(item.GetMaxQuantity());
                item.IncreaseQuantity(item.GetMaxQuantity());
            }
        }
    }

    public void RemoveProductCount(Stack stack, int value)
    {
        foreach (var item in _products)
        {
            if (item.Product.ProductType == stack.Product.ProductType)
            {
                item.DecreaseQuantity(value);
                _freeCapacity += value;
                OnStackChanged?.Invoke(value);
                Debug.Log("event value to remove = " + value);
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
