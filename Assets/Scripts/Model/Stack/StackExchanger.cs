using UnityEngine;

[RequireComponent(typeof(StackMover))]

public class StackExchanger : MonoBehaviour
{
    private StackMover _stackMover;
    private int _changedValue = 0;

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
            Debug.Log(otherStackMover.GetStacks().Count);
            TryGive(otherStackMover);
        }

        if(collider.TryGetComponent(out IGiver iGiver))
        {
            StackMover otherStackMover = collider.GetComponent<StackMover>();
            Debug.Log(otherStackMover.GetStacks().Count);
            TryTake(otherStackMover);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out StackMover stackMover))
            stackMover.OnStackChanged -= SetChangedValue;
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
                stackMover.AddProductCount(item);
                _stackMover.RemoveProductCount(item, _changedValue);
            }
        }
    }

    private void SetChangedValue(int value)
    {
        _changedValue = value;
    }
}
