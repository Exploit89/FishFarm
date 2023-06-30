using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    [SerializeField] private StackUIPanel _StackUIPanel;

    private Wallet _wallet;
    private Bag _bag;
    private StackMover _stackMover;
    private int _startStackValue = 30; // test

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Start()
    {
        _wallet.GetStartMoney();
        _bag = GetComponent<Bag>();
        _stackMover = GetComponent<StackMover>();
        _stackMover.CreateStacks(_startStackValue);
        _StackUIPanel.CreateUIStackView();
    }
}
