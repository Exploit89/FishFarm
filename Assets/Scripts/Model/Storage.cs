using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StackMover))]

public class Storage : MonoBehaviour
{
    private List<Stack> _products;
    private StackMover _stackMover;
    private string _name;
    private int _startStackValue = 0;

    private void Start()
    {
        _stackMover = GetComponent<StackMover>();
        _stackMover.CreateStacks(_startStackValue);
    }
}
