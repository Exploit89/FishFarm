using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Stack))]
[RequireComponent(typeof(SpriteRenderer))]

public class StackView : MonoBehaviour
{
    [SerializeField] private Stack _stack;
    [SerializeField] private List<SpriteRenderer> _sprites;

    private Sprite _image;
    private float _stackOffsetX = 1f;
    private float _stackOffsetY = 0.5f;

    private void Start()
    {
        _sprites = new List<SpriteRenderer>();
        _image = GetComponent<Stack>().Icon;
        SetStackOffsetX();
        Render();
    }

    private void Render()
    {
        for (int i = 0; i < _stack.Quantity; i++)
        {
            GameObject sprite = Instantiate(new GameObject(), new Vector3(_stackOffsetX, 0, 0), Quaternion.identity, transform);
            sprite.AddComponent<SpriteRenderer>();
            sprite.GetComponent<SpriteRenderer>().sprite = _image;
            sprite.transform.position += new Vector3(0, _stackOffsetY*i, 0);
        }
    }

    private void SetStackOffsetX()
    {
        switch(_stack.Product.ProductType)
        {
            case ProductType.Fillet:
                _stackOffsetX = 0.5f;
                break;
            case ProductType.Fresh:
                _stackOffsetX = 1f;
                break;
            case ProductType.Frozen:
               _stackOffsetX = 1.5f;
                break;
            case ProductType.Conserve:
                _stackOffsetX = 2;
                break;
            default:
                 _stackOffsetX = 0.5f;
                break;
        }
    }
}
