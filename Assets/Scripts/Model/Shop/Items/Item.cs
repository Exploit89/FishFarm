using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private int _price;

    public Sprite Icon => _icon;
    public string Label => _label;
    public int Price => _price;
}
