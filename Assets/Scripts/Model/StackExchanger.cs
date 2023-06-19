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
        if (collider.TryGetComponent(out StackMover stackMover))
        {
            Debug.Log(gameObject.name + " entered in " + stackMover.gameObject.name);
            TryTake(stackMover);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out StackMover stackMover))
        {
            foreach (var item in stackMover.GetStacks())
            {
                Debug.Log(item.Product.name + item.Quantity);
            }
        }
    }

    private void TryTake(StackMover stackMover)
    {
        if(IsValidExchange(stackMover))
        {
            Debug.Log("WTF?");

            foreach (var item in stackMover.GetStacks())
            {
                Debug.Log(item.Product.ProductType);
                Debug.Log(_stackMover.GetComponent<ITaker>().GetProductTypes()[0]);
                Debug.Log(_stackMover.GetComponent<ITaker>().GetProductTypes()[1]);
                Debug.Log(_stackMover.GetComponent<IGiver>().GetProductTypes()[0]);
                Debug.Log(_stackMover.GetComponent<IGiver>().GetProductTypes()[1]);
                if (_stackMover.GetComponent<ITaker>().GetProductTypes().Contains(item.Product.ProductType))
                {
                    Debug.Log("before add count" + item.Quantity);
                    _stackMover.AddProductCount(item);
                    Debug.Log("after add count");
                    Debug.Log("before remove count" + _changedValue);
                    stackMover.RemoveProductCount(item, _changedValue);
                    Debug.Log("after remove count");
                    Debug.Log(item.Quantity.ToString());
                }
            }
        }
    }

    private void SetChangedValue(int value)
    {
        _changedValue = value;
    }

    private bool IsValidExchange(StackMover stackMover)
    {
        if (stackMover.TryGetComponent(out IGiver iGiver) && _stackMover.TryGetComponent(out ITaker iTaker))
        {
            Debug.Log("IsValidExchange");
            return true;
        }
        return false;
    }
}
