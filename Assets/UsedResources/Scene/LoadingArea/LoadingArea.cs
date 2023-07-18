using UnityEngine;

public class LoadingArea : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Wallet>().SetMaxCash(1000);
        GetComponent<ITaker>().SetTakeable(true);
    }
}
