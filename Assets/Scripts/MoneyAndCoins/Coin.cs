using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0f;
    }

    private void OnCollisionEnter()
    {
        Destroy(GetComponent<AudioSource>(), 1);
        Destroy(this);
    }
}