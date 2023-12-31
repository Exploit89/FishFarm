using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Item _item;

    public event UnityAction<Item, ItemView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_item, this);
    }

    public void Render(Item item)
    {
        _item = item;
        _label.text = _item.Label;
        _price.text = _item.Price.ToString();
        _icon.sprite = _item.Icon;
    }
}
