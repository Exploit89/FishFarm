using System;
using System.Collections.Generic;
using UnityEngine;

public class StackCreator : MonoBehaviour
{
    [SerializeField] private Stack _stackPrefab;

    private int _startQuantity = 10;

    public List<Stack> CreateStacks()
    {
        List<Stack> stacks = new List<Stack>();

        foreach (ProductType productType in Enum.GetValues(typeof(ProductType)))
        {
            Stack stack = Instantiate(_stackPrefab, transform);
            stack.Initialize(new Product(), _startQuantity);
            stack.Product.SetProductType(productType);
            stack.name = stack.Product.Name;
            stacks.Add(stack);
        }
        return stacks;
    }
}
