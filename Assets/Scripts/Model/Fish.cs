using System.Collections.Generic;
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
    private Quality _quality;
    private int _lifeDays;
    private int _maxLifeDays;

    private Dictionary<Quality, int> _freshProductValues = new Dictionary<Quality, int>()
    {
        { Quality.Low, 1 },
        { Quality.Medium, 2 },
        { Quality.High, 3 },
        { Quality.Extra, 5 }
    };

    public string Name { get; private set; }

    public event UnityAction<int> FishReady;

    private void OnEnable()
    {

        _dayCounter = gameObject.AddComponent<DayCounter>();
        _dayCounter.DayPassed += PassOneDay;
    }

    private void OnDisable()
    {
        _dayCounter.DayPassed -= PassOneDay;
    }

    public void PassOneDay()
    {
        _lifeDays++;

        if (_lifeDays > _maxLifeDays)
        {
            FishReady?.Invoke(_freshProductValues[_quality]);
        }
    }

    public void Init(Item item)
    {
        Name = item.name;
        _quality = item.Quality;
        _maxLifeDays = item.MaxLifeDays;
    }
}
