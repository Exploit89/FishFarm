using UnityEngine;

public class BaseLoadingArea : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Wallet>().SetMaxCash(0);
        GetComponent<ITaker>().SetTakeable(true);
    }
}
