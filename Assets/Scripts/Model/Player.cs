using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _freeCapacity;
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
        Stack stack = new Stack();
        _products = stack.CreateStacks();
    }

    private void ClearStacks()
    {
        _products.Clear();
    }

    private int GetPossibleQuantity(int spaceToCapture)
    {
        int possibleSpace = 0;
        int neededSpace = _freeCapacity - spaceToCapture;

        if (neededSpace < 0)
        {
            possibleSpace = spaceToCapture + neededSpace;
            return possibleSpace;
        }
        return spaceToCapture;
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
