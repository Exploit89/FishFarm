using UnityEngine;

public class Stack : MonoBehaviour
{
    private int _minQuantity = 0;
    private int _maxQuantity = 20;

    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public void IncreaseQuantity(int value)
    {
        if(Quantity + value <= _maxQuantity)
            Quantity += value;
        else 
            Quantity = _maxQuantity;
        Debug.Log("Quantity increased, now it = " + Quantity);
    }

    public void DecreaseQuantity(int value)
    {
        if (Quantity - value >= _minQuantity)
            Quantity -= value;
        else
            Quantity = 0;
        Debug.Log("Quantity decreased, now it = " + Quantity);
    }

    public void Initialize(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public void SetMaxQuantity(int value)
    {
        _maxQuantity = value;
    }
}
