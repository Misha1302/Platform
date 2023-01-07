using Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platform
{
    public class PlatformRotate : MonoBehaviour
    {
        [FormerlySerializedAs("mode")] public int Mode;
        [SerializeField] private Vector3 rotateVectorFactor;
        [SerializeField] private Accelerometer accelerometer;
        [SerializeField] private int maxRotateX = 60;
        [SerializeField] private int maxRotateY = 30;

        private Transform transform;


        private void Awake()
        {
            Mode = SettingsData.Mode;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        private void Start()
        {
            transform = ((Component)this).transform;

            switch (SettingsData.SetTextureIndex)
            {
                case 2:
                    rotateVectorFactor *= 0.75f;
                    break;
                case 4:
                    rotateVectorFactor *= 0.5f;
                    break;
            }
        }

        private void Update()
        {
            var vec = new Vector3(accelerometer.AccelerometerVector3.z, 0, -accelerometer.AccelerometerVector3.x);
            vec = Vector3.Scale(vec, rotateVectorFactor);
            transform.Rotate(vec);

            vec = transform.rotation.eulerAngles;

            if (vec.x < 180 && vec.x > maxRotateX) vec.x = maxRotateX;
            if (vec.x > 180 && vec.x < 360 - maxRotateX) vec.x = 360 - maxRotateX;

            if (Mode == 2)
            {
                if (vec.z < 180 && vec.z > maxRotateY) vec.z = maxRotateY;
                if (vec.z > 180 && vec.z < 360 - maxRotateY) vec.z = 360 - maxRotateY;
            }
            else
            {
                vec.z = 0f;
            }

            vec.y = -45;

            transform.rotation = Quaternion.Euler(vec);
        }
    }
}