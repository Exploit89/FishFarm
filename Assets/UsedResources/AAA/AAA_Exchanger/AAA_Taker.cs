using System.Collections.Generic;
using UnityEngine;

public class AAA_Taker : MonoBehaviour
{
    [SerializeField] private List<AAAStack> _stacks;
    [SerializeField] private AAAStackMover _takerStackMover;
    [SerializeField] private AAAPlayerEvents _playerEvents;

    private AAAStackMover _giverStackMover;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out AAAStackMover playerStackMover))
        {
            _giverStackMover = playerStackMover;
            TryTake(_giverStackMover);
        }
    }

    private void TryTake(AAAStackMover playerStackMover)
    {
        foreach (var giverStack in _stacks)
        {
            foreach (var takerStack in playerStackMover.GetStacks())
            {
                if (giverStack.ProductType == takerStack.ProductType)
                {
                    AAAStack takerCurrentStack = _takerStackMover.GetStack(takerStack);
                    AAAStack giverCurrentStack = _giverStackMover.GetStack(giverStack);
                    int oldValue = giverCurrentStack.Quantity;
                    takerCurrentStack.IncreaseQuantity(oldValue);
                    giverCurrentStack.DecreaseQuantity(oldValue);
                    _playerEvents.OnStackChanged(takerCurrentStack, giverCurrentStack, oldValue);
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
