using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed = false;

    public Sprite Icon => _icon;
    public string Label => _label;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;

    public void Buy()
    {
        _isBuyed = true;
    }
}
