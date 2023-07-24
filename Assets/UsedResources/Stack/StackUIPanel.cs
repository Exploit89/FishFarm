using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackUIPanel : MonoBehaviour
{
    [SerializeField] private StackMover _stackMover;
    [SerializeField] private StackExchanger _stackExchanger;
    [SerializeField] private StackUIView _template;
    [SerializeField] private GameObject _itemContainer;

    private List<StackUIView> _stackViews;
    private List<Stack> _playerStacks;

    private void OnEnable()
    {
        _stackExchanger.UpdateStackCount += UpdateUIStackView;
    }

    private void OnDisable()
    {
        _stackExchanger.UpdateStackCount -= UpdateUIStackView;
    }

    private void AddItem(Stack stack)
    {
        StackUIView view = Instantiate(_template, _itemContainer.transform);
        view.name = stack.name;
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

    private void UpdateUIStackView()
    {
        foreach (var item in _itemContainer.GetComponentsInChildren<StackUIView>(true))
        {
            item.gameObject.SetActive(true);
            StopCoroutine(SetZero(item));
        }

        for (int i = 0; i < _stackMover.GetStacks().Count; i++)
        {
            _itemContainer.GetComponentsInChildren<StackUIView>()[i].Render(_stackMover.GetStacks()[i]);
        }

        foreach (var item in _itemContainer.GetComponentsInChildren<StackUIView>(true))
        {
            if (Mathf.Round(item.GetValue()) == 0)
            {
                StartCoroutine(SetZero(item));
            }
            else if (Mathf.Round(item.GetLastValue()) == 0 && !item.IsChanged())
            {
                StartCoroutine(SetZero(item));
            }
        }
    }

    private IEnumerator SetZero(StackUIView item)
    {
        yield return new WaitForSeconds(item.GetTweenerSpeed());
        item.gameObject.SetActive(false);
    }
}
