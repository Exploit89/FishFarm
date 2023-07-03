using System.Collections.Generic;
using UnityEngine;

public class StackImages : MonoBehaviour
{
    [SerializeField] private Sprite _freshIcon;
    [SerializeField] private Sprite _filletIcon;
    [SerializeField] private Sprite _conserveIcon;
    [SerializeField] private Sprite _frozenIcon;

    private Dictionary<ProductType, Sprite> _icons;

    private void Awake()
    {
        _icons = new Dictionary<ProductType, Sprite>();
        _icons.Add(ProductType.Fresh, _freshIcon);
        _icons.Add(ProductType.Fillet, _filletIcon);
        _icons.Add(ProductType.Conserve, _conserveIcon);
        _icons.Add(ProductType.Frozen, _frozenIcon);
    }

    public Sprite GetSprite(ProductType type)
    {
        return _icons[type];
    }
}
