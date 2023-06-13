using UnityEngine;
using UnityEngine.Events;

public class DayCounter : MonoBehaviour
{
    private int _dayCount;
    private float _time = 0;
    private int _timerMultiplier = 3;
    private int _dayPassBoard = 10;

    public event UnityAction DayPassed;

    private void Update()
    {
        AddDay();
    }

    private void AddDay()
    {
        _time += _timerMultiplier * Time.deltaTime;

        if(_time > _dayPassBoard)
        {
            _dayCount++;
            _time = 0;
        }
        Debug.Log(_dayCount);
    }
}
