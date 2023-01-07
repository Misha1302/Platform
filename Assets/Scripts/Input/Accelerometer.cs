using UnityEngine;

namespace Input
{
    public class Accelerometer : MonoBehaviour
    {
        public Vector3 AccelerometerVector3 { get; private set; }
        public Quaternion AccelerometerQuaternion => Quaternion.Euler(AccelerometerVector3);

        private void Awake()
        {
            AccelerometerVector3 = Vector3.zero;
        }

        // Update is called once per frame
        private void Update()
        {
            var dir = Vector3.zero;
            dir.x = -UnityEngine.Input.acceleration.y;
            dir.z = UnityEngine.Input.acceleration.x;

            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            dir *= Time.deltaTime;

            AccelerometerVector3 = dir;
        }
    }
}