using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AAA_Giver : MonoBehaviour
{
    [SerializeField] private List<AAAStack> _stacks;
    [SerializeField] private AAAStackMover _giverStackMover;

    private AAAStackMover _takerStackmover;

    public event UnityAction<AAAStack, AAAStack, int> StackGiven;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out AAA_Taker taker))
        {
            if(collider.TryGetComponent(out Player player))
                _takerStackmover = taker.GetComponent<AAAStackMover>();
            else
                _takerStackmover = taker.GetComponentInParent<AAAStackMover>();
            TryGive(taker);
        }
    }

    private void TryGive(AAA_Taker taker)
    {
        foreach (var giverStack in _stacks)
        {
            foreach (var takerStack in taker.GetStacks())
            {
                if (giverStack.ProductType == takerStack.ProductType)
                {
                    AAAStack takerCurrentStack = _takerStackmover.GetStack(takerStack);
                    AAAStack giverCurrentStack = _giverStackMover.GetStack(giverStack);
                    int oldValue = giverCurrentStack.Quantity;
                    takerCurrentStack.IncreaseQuantity(oldValue);
                    giverCurrentStack.DecreaseQuantity(oldValue);
                    StackGiven?.Invoke(takerCurrentStack, giverCurrentStack, oldValue);
                }
            }
        }
    }

    public List<AAAStack> GetStacks()
    {
        List<AAAStack> stacks = new List<AAAStack>();
        stacks = _stacks;
        return stacks;
    }
}
