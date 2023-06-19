using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Capacity))]

public class Storage : MonoBehaviour
{
    private List<Stack> _products;
    private Capacity _capacity;
    private StackMover _stackMover;
    private string _name;
    private int _startCapacity = 50;

    private void Start()
    {
        _stackMover = GetComponent<StackMover>();
        _stackMover.CreateStacks();
        _capacity = GetComponent<Capacity>();
        _capacity.SetCapacity(_startCapacity);
    }

    private void OnEnable()
    {

    }

    private void TakeStack(Stack stack)
    {
        _stackMover.AddProductCount(stack);
    }

    private void DropStack(Stack stack)
    {
        _stackMover.RemoveProductCount(stack);
    }
}
