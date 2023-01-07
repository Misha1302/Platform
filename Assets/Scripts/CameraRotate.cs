using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotateVector;
    private Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        camera.Rotate(rotateVector * Time.deltaTime);
    }
}