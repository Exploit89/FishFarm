using UnityEngine;

public class LoadingArea : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Wallet>().SetMaxCash(1500); // test
        GetComponent<ITaker>().SetTakeable(true);
    }
}
