using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Stack))]
[RequireComponent(typeof(SpriteRenderer))]

public class StackView : MonoBehaviour
{
    [SerializeField] private Stack _stack;
    [SerializeField] private List<GameObject> _sprites;

    private Sprite _image;
    private float _stackOffsetX = 1f;
    private float _stackOffsetY = 0.5f;

    private void Start()
    {
        _sprites = new List<GameObject>();
        _image = GetComponent<Stack>().Icon;
        SetStackOffsetX();
        CreateStackViews();
    }

    private void OnEnable()
    {
        GetComponentInParent<StackMover>().OnStackChanged += Render;
    }

    private void OnDisable()
    {
        if(GetComponentInParent<StackMover>() != null)
            GetComponentInParent<StackMover>().OnStackChanged -= Render;
    }

    private void CreateStackViews()
    {
        for (int i = 0; i < _stack.Quantity; i++)
        {
            GameObject sprite = Instantiate(new GameObject(), new Vector3(_stackOffsetX, 0, 0), Quaternion.identity, transform);
            sprite.AddComponent<SpriteRenderer>();
            sprite.GetComponent<SpriteRenderer>().sprite = _image;
            sprite.transform.position += new Vector3(0, _stackOffsetY * i, 0);
            _sprites.Add(sprite);
        }
    }

    private void Render(int count = 0)
    {
        if (_sprites.Count != 0)
        {
            foreach (var item in _sprites)
            {
                item.SetActive(false);
            }
            for (int i = 0; i < _stack.Quantity; i++)
            {
                _sprites[i].SetActive(true);
            }
        }
    }

    private void SetStackOffsetX()
    {
        switch (_stack.Product.ProductType)
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
