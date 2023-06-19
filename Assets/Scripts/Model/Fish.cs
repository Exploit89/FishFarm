using UnityEngine;
using UnityEngine.Events;

public enum Quality
{
    Low,
    Medium,
    High,
    Extra
}

public class Fish : MonoBehaviour
{
    private DayCounter _dayCounter;
    private string _name;
    private Quality _quality;
    private int _growthDays;
    private int _lifeDays;
    private int _maxLifeDays;
    private int _health;
    private int _maxHealth;
    private int _growthWeightValue;
    private int _deadWeight;
    private int _maxWeight;
    private float _weight;

    public event UnityAction FishDied;

    private void OnEnable()
    {
        _dayCounter = gameObject.AddComponent<DayCounter>();
        _dayCounter.DayPassed += PassOneDay;
    }

    private void OnDisable()
    {
        _dayCounter.DayPassed -= PassOneDay;
    }

    private bool IsDeadWeight()
    {
        return _deadWeight > _weight;
    }

    public void AddWeight(float multiplier)
    {
        _weight += multiplier * _growthWeightValue;
        Debug.Log("Weight added, total = " + _weight);

        if (_weight > _maxWeight )
            _weight = _maxWeight;
    }

    public void RemoveWeight(float multiplier)
    {
        _weight /= multiplier;
        Debug.Log("Weight removed, total = " + _weight);

        if (IsDeadWeight())
            FishDied?.Invoke();
    }

    public void AddHealth()
    {
        _health++;
        Debug.Log("Health added, total = " + _health);

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void RemoveHealth()
    {
        _health--;

        if(_health <= 0)
        {
            _health = 0;
            FishDied?.Invoke();
            Debug.Log("Fish died - " + _name);
        }
    }

    public void PassOneDay()
    {
        _lifeDays++;
        //Debug.Log("day passed, total = " + _lifeDays);

        if (_lifeDays > _maxLifeDays)
        {
            FishDied?.Invoke();
            //Debug.Log("Fish died - " + _name);
        }
    }
}
