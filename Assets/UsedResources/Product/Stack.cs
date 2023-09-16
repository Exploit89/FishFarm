using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private ProductType _productType;
    [SerializeField] private Sprite _image;

    public ProductType ProductType => _productType;
    public Sprite Image => _image;
    public int Quantity { get; private set; }
    public string Label { get; private set; }

    public void IncreaseQuantity(int value)
    {
        Quantity += value;
    }

    public void DecreaseQuantity(int value)
    {
        Quantity -= value;
    }
}
