using UnityEngine;

public class LoadingArea : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Wallet>().SetMaxCash(500); // test
        GetComponent<ITaker>().SetTakeable(true);
    }
}
