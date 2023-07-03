using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _fishPrefab;
    [SerializeField] private Transform fishAnchor;
    [SerializeField] private Attractor _attractor;
    [SerializeField] private CashExchanger _playerCashExchanger;

    private List<Swimer> _fishes;

    public event UnityAction<Fish> FishCreated;

    void Awake()
    {
        _fishes = new List<Swimer>();
    }

    private void OnEnable()
    {
        _playerCashExchanger.ItemBought += InstantiateFish;
    }

    private void OnDisable()
    {
        _playerCashExchanger.ItemBought -= InstantiateFish;
    }

    public void InstantiateFish(Item item)
    {
        GameObject fish = Instantiate(_fishPrefab, gameObject.transform);
        Fish fishComponent = fish.GetComponent<Fish>();
        fishComponent.Init(item);
        FishCreated?.Invoke(fishComponent);
        Swimer swimer = fish.GetComponent<Swimer>();
        fish.GetComponent<Swimer>().Init(this, _attractor);
        swimer.transform.SetParent(fishAnchor);
        _fishes.Add(swimer);
    }
}
