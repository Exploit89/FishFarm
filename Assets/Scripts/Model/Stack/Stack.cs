using UnityEngine;

public class Stack : MonoBehaviour
{
    private int _minQuantity = 0;
    private int _maxQuantity = 20;

    public Product Product { get; private set; }
    public Sprite Icon { get; private set; }
    public int Quantity { get; private set; }
    public string Label { get; private set; }

    public void IncreaseQuantity(int value)
    {
        if(Quantity + value <= _maxQuantity)
            Quantity += value;
        else 
            Quantity = _maxQuantity;
    }

    public void DecreaseQuantity(int value)
    {
        if (Quantity - value >= _minQuantity)
            Quantity -= value;
        else
            Quantity = 0;
    }

    public void Initialize(Product product, int quantity, Sprite icon)
    {
        Product = product;
        Quantity = quantity;
        Icon = icon;
    }

    public void SetMaxQuantity(int value)
    {
        _maxQuantity = value;
    }

    public int GetMaxQuantity()
    {
        return _maxQuantity;
    }

    public void SetLabel(string label)
    {
        Label = label;
    }
}
