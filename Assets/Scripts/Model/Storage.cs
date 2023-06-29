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
    private int _startStackValue = 0;

    private void Start()
    {
        _stackMover = GetComponent<StackMover>();
        _stackMover.CreateStacks(_startStackValue);
        _capacity = GetComponent<Capacity>();
        _capacity.SetCapacity(_startCapacity);
    }
}
