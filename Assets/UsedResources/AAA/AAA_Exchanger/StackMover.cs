using System.Collections.Generic;
using UnityEngine;

public class StackMover : MonoBehaviour
{
    [SerializeField] private List<Stack> _stackPrefabs;
    [SerializeField] private int _startStacksCount;

    private List<Stack> _stacks;

    private void Awake()
    {
        _stacks = new List<Stack>();

        foreach (var item in _stackPrefabs)
        {
            var newItem = Instantiate(item, transform);
            newItem.IncreaseQuantity(_startStacksCount); // test
            _stacks.Add(newItem);
        }
    }

    public Stack GetStack(Stack stack)
    {
        foreach (var item in _stacks)
        {
            if (item.ProductType == stack.ProductType)
                return item;
        }
        return null;
    }

    public List<Stack> GetStacks()
    {
        List<Stack> stacks = new List<Stack>();
        stacks = _stacks;
        return stacks;
    }

    public bool CanTake()
    {
        int count = 0;

        foreach (var stack in _stacks)
        {
            count += stack.Quantity;
        }

        if (count == 0)
            return true;
        else
            return false;
    }
}
