using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    public event UnityAction<Stack, Stack, int> StackChanged;

    public void OnStackChanged(Stack taker, Stack giver, int value)
    {
        StackChanged?.Invoke(taker, giver, value);
    }
}
