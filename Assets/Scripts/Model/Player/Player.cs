using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Capacity))]
[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Bag _bag;
    private Capacity _capacity;
    private StackMover _stackMover;
    private int _startCapacity = 100;

    public event UnityAction<Wallet> WalletCreated;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Start()
    {
        _wallet.GetStartMoney();
        _bag = GetComponent<Bag>();
        _stackMover = GetComponent<StackMover>();
        _capacity = GetComponent<Capacity>();
        _capacity.SetCapacity(_startCapacity);
        _stackMover.CreateStacks();
    }
}
