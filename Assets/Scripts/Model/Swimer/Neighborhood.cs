using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Neighborhood : MonoBehaviour
{
    private List<Swimer> _neighbors;
    private SphereCollider _collider;
    private float _neighborDistance = 2f;
    private float _colliderDistance = 1f;
    private int _colliderByDistanceMltiplier = 2;

    public Vector3 AveragePosition
    {
        get
        {
            Vector3 average = Vector3.zero;
            if (_neighbors.Count == 0 || _neighbors == null) return average;

            for (int i = 0; i < _neighbors.Count; i++)
            {
                average += _neighbors[i].FishStartPosition;
            }
            average /= _neighbors.Count;

            return average;
        }
        private set { }
    }

    public Vector3 AverageVelocity
    {
        get
        {
            Vector3 average = Vector3.zero;

            if (_neighbors.Count == 0 || _neighbors == null) return average;

            for (int i = 0; i < _neighbors.Count; i++)
            {
                average += _neighbors[i].GetRigidbodyVelocity();
            }
            average /= _neighbors.Count;
            return average;
        }
        private set { }
    }

    public Vector3 AverageClosePosition
    {
        get
        {
            Vector3 average = Vector3.zero;
            Vector3 delta;
            int nearCount = 0;

            if (_neighbors.Count == 0 || _neighbors == null) return average;

            for (int i = 0; i < _neighbors.Count; i++)
            {
                delta = _neighbors[i].FishStartPosition - transform.position;

                if (delta.magnitude <= _colliderDistance)
                {
                    average += _neighbors[i].FishStartPosition;
                    nearCount++;
                }
            }

            if (nearCount == 0) return average;
            average /= nearCount;
            return average;
        }
        private set { }
    }

    private void Awake()
    {
        _neighbors = new List<Swimer>();
    }

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _neighborDistance / _colliderByDistanceMltiplier;
    }

    private void FixedUpdate()
    {
        if (_collider.radius != _neighborDistance / _colliderByDistanceMltiplier)
        {
            _collider.radius = _neighborDistance / _colliderByDistanceMltiplier;
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        Swimer swimer = otherCollider.GetComponent<Swimer>();
        if (swimer != null)
        {
            if (_neighbors.IndexOf(swimer) == -1)
                _neighbors.Add(swimer);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        Swimer swimer = otherCollider.GetComponent<Swimer>();
        if (swimer != null)
        {
            if (_neighbors.IndexOf(swimer) != -1)
                _neighbors.Remove(swimer);
        }
    }
}
