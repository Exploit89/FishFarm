using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Value { get; private set; }

    private bool IsEnoughValue(int value)
    {
        return Value - value >= 0;
    }

    public void AddValue(int value)
    {
        Value += value;
    }

    public void RemoveValue(int value)
    {
        if (IsEnoughValue(value))
            Value -= value;
    }
}
