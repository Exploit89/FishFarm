using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _startMoney = 1000;
    private int _maxValue = 100000;

    public int Value { get; private set; }

    public event UnityAction<int> OnValueChanged;

    private bool IsEnoughValue(int value)
    {
        return Value - value >= 0;
    }

    private int GetPossibleValue(int value)
    {
        if(value >= _maxValue - Value)
            return _maxValue - Value;
        return value;
    }

    public void GetStartMoney()
    {
        Value = _startMoney;
        OnValueChanged?.Invoke(Value);
    }

    public void AddValue(int value)
    {
        int possibleValue = GetPossibleValue(value);
        Value += possibleValue;
        OnValueChanged?.Invoke(possibleValue);
        Debug.Log("value added, total = " + possibleValue);
    }

    public bool CanBuy(int value)
    {
        if(IsEnoughValue(value))
            return true;
        return false;

    }

    public void RemoveValue(int value)
    {
        if (IsEnoughValue(value))
        {
            Value -= value;
            OnValueChanged?.Invoke(value);
            Debug.Log("value removed, total = " + Value);
        }
    }

    public void RemoveFixedValue(int value)
    {
        Value -= value;
        OnValueChanged?.Invoke(value);
        Debug.Log("value removed, total = " + Value);
    }

    public void SetMaxCash(int value)
    {
        _maxValue = value;
    }
}
