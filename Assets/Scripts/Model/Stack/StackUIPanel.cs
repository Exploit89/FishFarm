using System.Collections.Generic;
using UnityEngine;

public class StackUIPanel : MonoBehaviour
{
    [SerializeField] private StackMover _stackMover;
    [SerializeField] private StackUIView _template;
    [SerializeField] private GameObject _itemContainer;

    private List<StackUIView> _stackViews;
    private List<Stack> _playerStacks;

    private void AddItem(Stack stack)
    {
        StackUIView view = Instantiate(_template, _itemContainer.transform);
        view.Render(stack);
        _stackViews.Add(view);
    }

    public void CreateUIStackView()
    {
        _stackViews = new List<StackUIView>();
        _playerStacks = _stackMover.GetStacks();

        for (int i = 0; i < _playerStacks.Count; i++)
        {
            AddItem(_playerStacks[i]);
        }
    }
}
