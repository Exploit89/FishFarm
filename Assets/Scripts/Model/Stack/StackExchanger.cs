using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackMover))]

public class StackExchanger : MonoBehaviour
{
    private StackMover _stackMover;
    private int _changedValue = 0;
    private bool _isGiven = false;

    public event UnityAction UpdateStackCount;

    private void Awake()
    {
        _stackMover = GetComponent<StackMover>();
    }

    private void OnEnable()
    {
        _stackMover.OnStackChanged += SetChangedValue;
    }

    private void OnDisable()
    {
        _stackMover.OnStackChanged -= SetChangedValue;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out StackMover stackMover))
            stackMover.OnStackChanged += SetChangedValue;
        
        if (collider.TryGetComponent(out ITaker iTaker))
        {
            StackMover otherStackMover = collider.GetComponent<StackMover>();
            TryGive(otherStackMover);
            UpdateStackCount?.Invoke();
        }

        if(collider.TryGetComponent(out IGiver iGiver) && !_isGiven)
        {
            StackMover otherStackMover = collider.GetComponent<StackMover>();
            TryTake(otherStackMover);
            UpdateStackCount?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out StackMover stackMover))
            stackMover.OnStackChanged -= SetChangedValue;
        _isGiven = false;
    }

    private void TryTake(StackMover stackMover)
    {
        foreach (var item in stackMover.GetStacks())
        {
            if (stackMover.GetComponent<IGiver>().GetProductTypes().Contains(item.Product.ProductType))
            {
                _stackMover.AddProductCount(item);
                stackMover.RemoveProductCount(item, _changedValue);
            }
        }
    }

    private void TryGive(StackMover stackMover)
    {
        foreach (var item in _stackMover.GetStacks())
        {
            if (stackMover.GetComponent<ITaker>().GetProductTypes().Contains(item.Product.ProductType))
            {
                if(item.Quantity > 0)
                {
                    stackMover.AddProductCount(item);
                    _stackMover.RemoveProductCount(item, _changedValue);

                    if (_changedValue > 0)
                        _isGiven = true;
                    _changedValue = 0;
                }
            }
        }
    }

    private void SetChangedValue(int value)
    {
        _changedValue = value;
    }
}
