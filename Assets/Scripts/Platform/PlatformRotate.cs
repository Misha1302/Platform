using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    public int mode;
    [SerializeField] private Vector3 rotateVectorFactor;
    [SerializeField] private Accelerometer accelerometer;
    [SerializeField] private int maxRotateX = 60;
    [SerializeField] private int maxRotateY = 30;

    private float _scale = 1;

    private Transform _transform;

    private void Awake()
    {
        mode = SettingsData.mode;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        _transform = transform;

        _scale = mode == 0 ? 1.2f : 1;

        var localScale = _transform.localScale;
        localScale = new Vector3(localScale.x * _scale, 0.5f, localScale.z * _scale);
        _transform.localScale = localScale;
    }

    private void Update()
    {
        var vec = new Vector3(accelerometer.AccelerometerVector3.z, 0, -accelerometer.AccelerometerVector3.x);
        vec = Vector3.Scale(vec, rotateVectorFactor);
        _transform.Rotate(vec);

        vec = _transform.rotation.eulerAngles;

        if (vec.x < 180 && vec.x > maxRotateX) vec.x = maxRotateX;
        if (vec.x > 180 && vec.x < 360 - maxRotateX) vec.x = 360 - maxRotateX;

        if (mode == 2)
        {
            if (vec.z < 180 && vec.z > maxRotateY) vec.z = maxRotateY;
            if (vec.z > 180 && vec.z < 360 - maxRotateY) vec.z = 360 - maxRotateY;
        }
        else
        {
            vec.z = 0f;
        }

        vec.y = -45;

        _transform.rotation = Quaternion.Euler(vec);
    }
}