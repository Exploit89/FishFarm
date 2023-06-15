using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _capacity = 20;
    private int _freeCapacity;
    private string _name;
    private List<Stack> _products;
    private Factory _factory; //

    private void Start()
    {
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

    private void OnEnable()
    {
        GameObject equipment = gameObject.GetComponentInParent<GameObject>(); //
        _factory = equipment.GetComponentInChildren<Factory>(); //
        _freeCapacity = _capacity;
    }

    private void CapturePlace(int value)
    {
        _freeCapacity -= value;
    }

    private void FreePlace(int value)
    {
        _freeCapacity += value;
    }

    private int GetPossibleQuantity(int spaceToCapture)
    {
        int possibleSpace = 0;
        int neededSpace = _freeCapacity - spaceToCapture;

        if(neededSpace < 0)
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
            if(item.Product.ProductType == stack.Product.ProductType)
            {
                Debug.Log("Storage stack qty before add = " + item.Quantity);
                item.IncreaseQuantity(GetPossibleQuantity(stack.Quantity));
                Debug.Log("Storage stack qty after add = " + item.Quantity);
            }
        }
    }
}
