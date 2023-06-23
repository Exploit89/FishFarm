using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CashExchanger))]

public class Bag : MonoBehaviour
{
    private CashExchanger _cashExchanger;
    private List<Item> _items;

    private void Awake()
    {
        _items = new List<Item>();
        _cashExchanger = GetComponent<CashExchanger>();
    }

    private void OnEnable()
    {
        _cashExchanger.ItemBought += AddItem;
    }

    private void OnDisable()
    {
        _cashExchanger.ItemBought -= AddItem;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }
}
