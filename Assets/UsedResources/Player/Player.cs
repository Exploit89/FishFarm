using UnityEngine;

[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    [SerializeField] private StackUIPanel _stackUIPanel;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Start()
    {
        _wallet.GetStartMoney();
        _stackUIPanel.CreateUIStackView();
    }
}
