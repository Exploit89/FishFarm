using UnityEngine;

public class Capacity : MonoBehaviour
{
    public int FreeCapacity { get; private set; }

    public void SetCapacity(int value)
    {
        FreeCapacity = value;
    }
}
