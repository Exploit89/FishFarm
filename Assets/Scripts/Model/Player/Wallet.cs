using UnityEngine;
using UnityEngine.Events;

public class Wallet
{
    private int _easyValue = 10000;
    private int _normalValue = 5000;
    private int _hardValue = 0;
    private int _maxValue = 0;

    public int Value { get; private set; }
    public int FixedPrice { get; private set; }

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

    public int GetStartMoney(DifficultySetup difficulty)
    {
        switch (difficulty.DifficultyLevel)
        {
            case Difficulty.Easy:
                return _easyValue;
            case Difficulty.Normal:
                return _normalValue;
            case Difficulty.Hard:
                return _hardValue;
            default:
                return 0;
        }
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

    public void SetFixedPrice(int value)
    {
        FixedPrice = value;
    }

    //public Wallet(DifficultySetup difficulty, int maxValue = 0)
    //{
    //    _maxValue = maxValue;
    //    Value = GetStartMoney(difficulty);
    //    OnValueChanged?.Invoke(Value);
    //}

    public Wallet(int maxValue = 0, int value = 0)
    {
        _maxValue = maxValue;
        FixedPrice = maxValue;
        Value = value;
    }
}
