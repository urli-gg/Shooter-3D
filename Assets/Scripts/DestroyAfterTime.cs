using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 5f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
