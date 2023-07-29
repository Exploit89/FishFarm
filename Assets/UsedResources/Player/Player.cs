using UnityEngine;

[RequireComponent(typeof(StackMover))]
[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    [SerializeField] private AAAStackUIPanel _stackUIPanel;

    private Wallet _wallet;
    private StackMover _stackMover;
    private int _startStackValue = 0; // test

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Start()
    {
        _wallet.GetStartMoney();
        _stackMover = GetComponent<StackMover>();
        _stackMover.CreateStacks(_startStackValue);
        _stackUIPanel.CreateUIStackView();
    }
}
