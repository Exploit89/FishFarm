using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _startMoney = 1000;
    private int _maxCash = 0;

    public int Value { get; private set; } = 0;

    public event UnityAction<int> OnValueChanged;

    private bool IsEnoughValue(int value)
    {
        return Value - value >= 0;
    }

    private int GetPossibleValue(int value)
    {
        if (value >= _maxCash - Value)
        {
            if (_maxCash - Value == 0 && Value != 0)
            {
                return 0;
            }
            return _maxCash - Value;
        }
        return value;
    }

    public void GetStartMoney()
    {
        Value = _startMoney;
        OnValueChanged?.Invoke(Value);
    }

    public int AddValue(int value)
    {
        int possibleValue = GetPossibleValue(value);
        Value += possibleValue;
        OnValueChanged?.Invoke(Value);
        return possibleValue;
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
            OnValueChanged?.Invoke(Value);
        }
    }

    public void RemoveFixedValue(int value)
    {
        Value -= value;
        OnValueChanged?.Invoke(Value);
    }

    public void SetMaxCash(int value)
    {
        _maxCash = value;
    }

    public int GetMaxValue()
    {
        return _maxCash;
    }
}
