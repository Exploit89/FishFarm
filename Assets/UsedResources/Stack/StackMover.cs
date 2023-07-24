using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackCreator))]

public class StackMover : MonoBehaviour
{
    [SerializeField] private List<Stack> _products;
    [SerializeField] private FishEvents _fishEvents;

    private StackCreator _stackCreator;

    public event UnityAction<int> OnStackChanged;
    public event UnityAction<Stack, int, Transform> OnNamedStackChanged;

    private void Awake()
    {
        _products = new List<Stack>();
        _stackCreator = GetComponent<StackCreator>();
    }

    private void OnEnable()
    {
        if(gameObject.TryGetComponent(out PoolStorage poolStorage))
        {
            _fishEvents.FishAdded += SubscribeOnFish;
        }
    }

    private void OnDisable()
    {
        if (gameObject.TryGetComponent(out Pool pool))
        {
            foreach (var item in _fishEvents.GetFishList())
            {
                item.FishReady -= AddFreshValue;
            }
        }
    }

    private void SubscribeOnFish(Fish fish)
    {
        fish.FishReady += AddFreshValue;
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
                int freeSpace = item.GetMaxQuantity() - item.Quantity;

                if (freeSpace < 0)
                    freeSpace = 0;

                if (stack.Quantity <= freeSpace)
                {
                    OnStackChanged?.Invoke(stack.Quantity);
                    OnNamedStackChanged?.Invoke(stack, stack.Quantity, gameObject.transform);
                    item.IncreaseQuantity(stack.Quantity);
                }
                else
                {
                    OnStackChanged?.Invoke(freeSpace);
                    OnNamedStackChanged?.Invoke(stack, freeSpace, gameObject.transform);
                    item.IncreaseQuantity(freeSpace);
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
                int newValue = item.DecreaseQuantity(value);
                OnStackChanged?.Invoke(newValue);
                OnNamedStackChanged?.Invoke(stack, newValue, gameObject.transform);
            }
        }
    }

    public List<Stack> GetStacks()
    {
        List<Stack> list = new List<Stack>();
        list = _products;
        return list;
    }

    public void AddFreshValue(int value)
    {
        if(gameObject.TryGetComponent(out PoolStorage poolStorage))
        {
            foreach (var item in _products)
            {
                if (item.Product.ProductType == ProductType.Fresh)
                {
                    int freeSpace = item.GetMaxQuantity() - item.Quantity;

                    if (value <= freeSpace)
                    {
                        item.IncreaseQuantity(value);
                        OnStackChanged?.Invoke(value);
                        OnNamedStackChanged?.Invoke(item, value, gameObject.transform);
                    }
                    else
                    {
                        item.IncreaseQuantity(freeSpace);
                        OnStackChanged?.Invoke(freeSpace);
                        OnNamedStackChanged?.Invoke(item, freeSpace, gameObject.transform);
                    }
                }
            }
        }
    }
}
