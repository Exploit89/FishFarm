using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductGiver : MonoBehaviour
{
    [SerializeField] private List<Stack> _stacks;
    [SerializeField] private StackMover _giverStackMover;
    [SerializeField] private PlayerEvents _playerEvents;

    private StackMover _takerStackMover;

    public event UnityAction StackGiven;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out StackMover playerStackMover))
        {
            _takerStackMover = playerStackMover;
            TryGive(_takerStackMover);
        }
    }

    private void TryGive(StackMover playerStackMover)
    {
        foreach (var giverStack in _stacks)
        {
            foreach (var takerStack in playerStackMover.GetStacks())
            {
                if (giverStack.ProductType == takerStack.ProductType)
                {
                    Stack takerCurrentStack = _takerStackMover.GetStack(takerStack);
                    Stack giverCurrentStack = _giverStackMover.GetStack(giverStack);
                    int oldValue = giverCurrentStack.Quantity;
                    takerCurrentStack.IncreaseQuantity(oldValue);
                    giverCurrentStack.DecreaseQuantity(oldValue);
                    _playerEvents.OnStackChanged(takerCurrentStack, giverCurrentStack, oldValue);
                }
            }
        }
    }

    public List<Stack> GetStacks()
    {
        List<Stack> stacks = new List<Stack>();
        stacks = _stacks;
        return stacks;
    }
}
