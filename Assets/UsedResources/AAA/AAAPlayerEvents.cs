using UnityEngine;
using UnityEngine.Events;

public class AAAPlayerEvents : MonoBehaviour
{
    public event UnityAction<AAAStack, AAAStack, int> StackChanged;

    public void OnStackChanged(AAAStack taker, AAAStack giver, int value)
    {
        StackChanged?.Invoke(taker, giver, value);
    }
}
