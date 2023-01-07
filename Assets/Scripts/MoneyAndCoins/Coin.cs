using UnityEngine;

namespace MoneyAndCoins
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbodyCoin;

        private void Start()
        {
            rigidbodyCoin.sleepThreshold = 0f;
            rigidbodyCoin.interpolation = RigidbodyInterpolation.Interpolate;
            rigidbodyCoin.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            Physics.defaultMaxDepenetrationVelocity = 50f;
        }

        private void OnCollisionEnter()
        {
            Destroy(GetComponent<AudioSource>());
            Destroy(this);
        }
    }
}