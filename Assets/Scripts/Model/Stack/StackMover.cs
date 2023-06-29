using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackCreator))]

public class StackMover : MonoBehaviour
{
    [SerializeField] private List<Stack> _products;

    private StackCreator _stackCreator;

    public event UnityAction<int> OnStackChanged;

    private void Awake()
    {
        _products = new List<Stack>();
        _stackCreator = GetComponent<StackCreator>();
    }

    private void ClearStacks()
    {
        if (_products != null)
            _products.Clear();
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
                if (stack.Quantity <= item.GetMaxQuantity())
                {
                    OnStackChanged?.Invoke(stack.Quantity);
                    item.IncreaseQuantity(stack.Quantity);
                }
                else
                {
                    OnStackChanged?.Invoke(item.GetMaxQuantity());
                    item.IncreaseQuantity(item.GetMaxQuantity());
                }
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
