using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        Vector3 position = new Vector3();
        position = transform.position;
        return position;
    }
}
