using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private CashExchanger _playerCashExchanger;
    [SerializeField] private ItemView _template;
    [SerializeField] private GameObject _itemContainer;

    private List<ItemView> _itemViews;

    private void Start()
    {
        _itemViews = new List<ItemView>();

        for (int i = 0; i < _items.Count; i++)
        {
            AddItem(_items[i]);
        }
    }

    private void OnEnable()
    {
        if (_itemViews != null)
        {
            foreach (var item in _itemViews)
            {
                item.SellButtonClick += OnSellButtonClick;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var item in _itemViews)
        {
            item.SellButtonClick -= OnSellButtonClick;
        }
    }

    private void AddItem(Item item)
    {
        ItemView view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(item);
        _itemViews.Add(view);
    }

    private void OnSellButtonClick(Item item, ItemView view)
    {
        TrySellItem(item);
    }

    private void TrySellItem(Item item)
    {
        _playerCashExchanger.TryShopBuy(item);
    }
}
