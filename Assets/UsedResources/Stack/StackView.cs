using UnityEngine;

[RequireComponent(typeof(Stack))]
[RequireComponent(typeof(SpriteRenderer))]

public class StackView : MonoBehaviour
{
    private Sprite _image;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _image = GetComponent<Stack>().Icon;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _image;
    }
}
