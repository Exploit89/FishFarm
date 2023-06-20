using UnityEngine;

public class Stack : MonoBehaviour
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public void IncreaseQuantity(int value)
    {
        Quantity += value;
        Debug.Log("Quantity increased, now it = " + Quantity);
    }

    public void DecreaseQuantity(int value)
    {
        Quantity -= value;
        Debug.Log("Quantity decreased, now it = " + Quantity);
    }

    public void Initialize(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}
