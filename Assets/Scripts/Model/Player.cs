using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
}
