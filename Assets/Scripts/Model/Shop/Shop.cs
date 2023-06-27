using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private Player _player;
    [SerializeField] private ItemView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            AddItem(_items[i]);
        }
    }

    private void AddItem(Item item)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(item);
    }

    private void OnSellButtonClick(Item item, ItemView view)
    {
        TrySellWeapon(item, view);
    }

    private void TrySellWeapon(Item item, ItemView view)
    {
        _player.GetComponent<CashExchanger>().TryShopBuy(item);
        item.Buy();
        view.SellButtonClick -= OnSellButtonClick;
    }
}
