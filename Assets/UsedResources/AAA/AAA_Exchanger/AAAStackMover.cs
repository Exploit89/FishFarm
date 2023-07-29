using System.Collections.Generic;
using UnityEngine;

public class AAAStackMover : MonoBehaviour
{
    [SerializeField] private List<AAAStack> _stackPrefabs;
    [SerializeField] private int _startStacksCount;

    private List<AAAStack> _stacks;

    private void Awake()
    {
        _stacks = new List<AAAStack>();

        foreach (var item in _stackPrefabs)
        {
            var newItem = Instantiate(item, transform);
            newItem.IncreaseQuantity(_startStacksCount); // test
            _stacks.Add(newItem);
        }
    }

    public AAAStack GetStack(AAAStack stack)
    {
        foreach (var item in _stacks)
        {
            if (item.ProductType == stack.ProductType)
                return item;
        }
        return null;
    }

    public List<AAAStack> GetStacks()
    {
        List<AAAStack> stacks = new List<AAAStack>();
        stacks = _stacks;
        return stacks;
    }
}
