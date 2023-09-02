using UnityEngine;

public class PoolFreshCreator : MonoBehaviour
{
    [SerializeField] private FishEvents _fishEvents;
    [SerializeField] private StackMover _giverStackMover;

    private void OnEnable()
    {
        _fishEvents.FishAdded += AddFresh;
    }

    private void OnDisable()
    {
        _fishEvents.FishAdded -= AddFresh;
    }

    private void AddFresh(Fish fish)
    {
        fish.FishReady += AddFreshValue;
    }

    private void AddFreshValue(int value)
    {
        foreach (var item in _giverStackMover.GetStacks())
        {
            if (item.ProductType == ProductType.Fresh)
            {
                item.IncreaseQuantity(value);
            }
        }
    }
}
