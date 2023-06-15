using UnityEngine;

public class Wallet
{
    private DifficultySetup _difficulty;
    private int _easyValue = 10000;
    private int _normalValue = 5000;
    private int _hardValue = 0;

    public int Value { get; private set; }

    private int GetStartMoney(DifficultySetup difficulty)
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

    private bool IsEnoughValue(int value)
    {
        return Value - value >= 0;
    }

    public void AddValue(int value)
    {
        Value += value;
        Debug.Log("value added, total = " + Value);
    }

    public void RemoveValue(int value)
    {
        if (IsEnoughValue(value))
        {
            Value -= value;
            Debug.Log("value removed, total = " + Value);
        }
    }

    public Wallet()
    {
        Value = GetStartMoney(_difficulty);
        Debug.Log("StartMoney get = " + Value);
    }
}
