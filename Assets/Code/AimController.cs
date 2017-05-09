using UnityEngine;

public class AimController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] float Sensitivity = 1f;
    [SerializeField] float MaxRotationDegrees = 1f;

    [Header("Components")]
    [SerializeField] Transform CameraPlaceholderTransform;
    [SerializeField] Transform CameraTransform;

    Quaternion InitialRotation;

	void Start () {
        InitialRotation = transform.localRotation;
    }
	
	void Update () {
        float rotationX = Input.GetAxisRaw("Mouse X");
        float rotationY = Input.GetAxisRaw("Mouse Y");

        rotationX *= Sensitivity;
        rotationY *= Sensitivity;

        CameraPlaceholderTransform.Rotate(0, rotationX, 0);
        CameraTransform.Rotate(-rotationY, 0, 0);
	}
}
