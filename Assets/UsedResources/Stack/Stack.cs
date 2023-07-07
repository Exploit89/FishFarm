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
        else if(value != 0)
            Quantity = _maxQuantity;
    }

    public int DecreaseQuantity(int value)
    {
        if (Quantity - value >= _minQuantity)
        {
            Quantity -= value;
        }
        else
        {
            value = Quantity;
            Quantity = 0;
            return value;
        }
        return value;
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
