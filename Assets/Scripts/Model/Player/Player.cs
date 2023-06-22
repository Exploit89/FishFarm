using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Capacity))]
[RequireComponent(typeof(Bag))]

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Bag _bag;
    private Capacity _capacity;
    private StackMover _stackMover;
    private DifficultySetup _difficulty;
    private int _startCapacity = 100;
    private int _maxCash = 100000;

    public event UnityAction<Wallet> WalletCreated;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    private void Start()
    {
        _difficulty = gameObject.AddComponent<DifficultySetup>();
        _wallet.GetStartMoney(_difficulty);
        WalletCreated?.Invoke(_wallet);
        _bag = GetComponent<Bag>();
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
