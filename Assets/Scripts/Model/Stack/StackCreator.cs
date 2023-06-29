using System;
using System.Collections.Generic;
using UnityEngine;

public class StackCreator : MonoBehaviour
{
    [SerializeField] private Stack _stackPrefab;
    [SerializeField] private StackImages _stackImages;

    private int _startQuantity = 0;

    public List<Stack> CreateStacks(int value = 0)
    {
        List<Stack> stacks = new List<Stack>();
        _startQuantity = value;

        foreach (ProductType productType in Enum.GetValues(typeof(ProductType)))
        {
            Stack stack = Instantiate(_stackPrefab, transform);
            stack.Initialize(new Product(), _startQuantity, _stackImages.GetSprite(productType));
            stack.Product.SetProductType(productType);
            stack.name = stack.Product.Name;
            stack.SetLabel(stack.name);
            stacks.Add(stack);
        }
        return stacks;
    }
}
