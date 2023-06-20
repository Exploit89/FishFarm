using UnityEngine;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Capacity))]

public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Capacity _capacity;
    private StackMover _stackMover;
    private int _startCapacity = 100;
    private DifficultySetup _difficulty;

    private void Start()
    {
        _difficulty = gameObject.AddComponent<DifficultySetup>();
        _wallet = new Wallet(_difficulty);
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
}
