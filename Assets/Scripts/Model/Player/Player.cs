using UnityEngine;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Capacity))]

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Capacity _capacity;
    private StackMover _stackMover;
    private DifficultySetup _difficulty;
    private int _startCapacity = 100;
    private int _maxCash = 100000;

    private void Start()
    {
        _difficulty = gameObject.AddComponent<DifficultySetup>();
        _wallet = new Wallet(_difficulty, _maxCash);
        _stackMover = GetComponent<StackMover>();
        _capacity = GetComponent<Capacity>();
        _capacity.SetCapacity(_startCapacity);
        _stackMover.CreateStacks();
    }

    private void TakeStack(Stack stack)
    {
        _stackMover.AddProductCount(stack);
    }

    private void DropStack(Stack stack)
    {
        _stackMover.RemoveProductCount(stack);
    }

    public Wallet GetWallet()
    {
        Wallet wallet = new Wallet();
        wallet = _wallet;
        return wallet;
    }
}
