using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _fishPrefab;
    [SerializeField] private Transform fishAnchor;
    [SerializeField] private Attractor _attractor;
    [SerializeField] private int _fishNumber = 10;
    [SerializeField] private float _spawnDelay = 0.1f;

    private List<Swimer> _fishes;

    void Awake()
    {
        _fishes = new List<Swimer>();
        InstantiateFish();
    }

    // TODO change to normal start spawn and next spawn
    public void InstantiateFish()
    {
        GameObject fish = Instantiate(_fishPrefab, gameObject.transform);
        Swimer swimer = fish.GetComponent<Swimer>();
        fish.GetComponent<Swimer>().Init(this, _attractor);
        swimer.transform.SetParent(fishAnchor);
        _fishes.Add(swimer);

        if (_fishes.Count < _fishNumber)
        {
            Invoke("InstantiateFish", _spawnDelay);
        }
    }
}
