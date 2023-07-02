using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishEvents : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private List<Fish> _fishList;

    public event UnityAction<Fish> FishAdded;

    private void Start()
    {
        _fishList = new List<Fish>();
    }

    private void OnEnable()
    {
        _spawner.FishCreated += AddFish;
    }

    private void OnDisable()
    {
        _spawner.FishCreated -= AddFish;
    }

    private void AddFish(Fish fish)
    {
        _fishList.Add(fish);
        FishAdded?.Invoke(fish);
    }

    public List<Fish> GetFishList()
    {
        List<Fish> list = new List<Fish>();
        list = _fishList;
        return list;
    }
}
