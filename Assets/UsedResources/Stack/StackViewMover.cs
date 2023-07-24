using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackViewMover : MonoBehaviour
{
    private List<StackView> _stackViews;
    private float _tweenerSpeed = 1f;

    private void Start()
    {
        foreach (var stackView in GetComponentsInChildren<StackView>(true))
        {
            _stackViews.Add(stackView);
        }
    }

    private void OnEnable()
    {
        foreach (var stackMover in GetComponentsInChildren<StackMover>(true))
        {
            stackMover.OnNamedStackChanged += Move;
        }
    }

    private void OnDisable()
    {
        foreach (var stackMover in GetComponentsInChildren<StackMover>(true))
        {
            stackMover.OnNamedStackChanged -= Move;
        }
    }

    private void ShowAll()
    {
        foreach (var stackView in _stackViews)
        {
            stackView.gameObject.SetActive(true);
        }
    }

    private void HideAll()
    {
        foreach (var stackView in _stackViews)
        {
            stackView.gameObject.SetActive(false);
        }
    }

    private void Show(Stack stack)
    {
        stack.gameObject.SetActive(true);
    }

    private void Hide(Stack stack)
    {
        stack.gameObject.SetActive(false);
    }

    private void Move(Stack stack, int value, Transform transform)
    {
        Hide(stack);
        stack.transform.position = gameObject.transform.position;
        Show(stack);
        stack.transform.DOMove(transform.position, _tweenerSpeed);
        SetHidden(stack);
    }

    private IEnumerator SetHidden(Stack stack)
    {
        yield return new WaitForSeconds(_tweenerSpeed);
        stack.gameObject.SetActive(false);
    }
}
