using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAStackUIPanel : MonoBehaviour
{
    [SerializeField] private AAA_Giver _stackGiver;
    [SerializeField] private AAAStackMover _stackMover;
    [SerializeField] private StackUIView _stackUIView;
    [SerializeField] private GameObject _itemContainer;

    private List<StackUIView> _stackViews;
    private List<AAAStack> _playerStacks;

    private void OnEnable()
    {
        _stackGiver.StackGiven += UpdateUIStackView;
    }

    private void OnDisable()
    {
        _stackGiver.StackGiven -= UpdateUIStackView;
    }

    private void AddItem(AAAStack stack)
    {
        StackUIView stackUIView = Instantiate(_stackUIView, _itemContainer.transform);
        stackUIView.name = stack.name;
        stackUIView.Render(stack);
        _stackViews.Add(stackUIView);
    }

    public void CreateUIStackView()
    {
        _stackViews = new List<StackUIView>();
        _playerStacks = new List<AAAStack>();
        _playerStacks = _stackMover.GetStacks();

        for (int i = 0; i < _playerStacks.Count; i++)
        {
            AddItem(_playerStacks[i]);
        }
    }

    private void UpdateUIStackView(AAAStack taker = null, AAAStack giver = null, int value = 0)
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
