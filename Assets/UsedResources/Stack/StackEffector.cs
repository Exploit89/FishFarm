using System.Collections.Generic;
using UnityEngine;

public class StackEffector : MonoBehaviour
{
    private List<StackView> _stackViews;

    private void Start()
    {
        _stackViews = new List<StackView>();

        foreach (var item in GetComponentsInChildren<StackView>())
        {
            _stackViews.Add(item);
            Debug.Log("item added" + item);
            item.OnStackExist += ShowStack;
        }
    }

    private void OnEnable()
    {
        if(_stackViews != null)
        {
            foreach (var item in _stackViews)
            {
                item.OnStackExist += ShowStack;
            }
        }
    }

    private void OnDisable()
    {
        if (_stackViews != null)
        {
            foreach (var item in _stackViews)
            {
                item.OnStackExist -= ShowStack;
            }
        }
    }

    private void ShowStack()
    {
        foreach(var item in _stackViews)
        {
            item.gameObject.SetActive(true);
        }
    }
}
