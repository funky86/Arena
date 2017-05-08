using UnityEngine;

public class AimController : MonoBehaviour {

    const float MaxRotationDegrees = 10f;

    Quaternion InitialRotation;

	void Start () {
        InitialRotation = transform.localRotation;
    }
	
	void Update () {
        Vector2 mousePosition = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        float degreesHorizontal = mousePosition.x;
        float degreesVertical = -1 * (mousePosition.y);

        //Camera.main.transform.Rotate(Camera.main.transform.up, degreesHorizontal);
        Camera.main.transform.localRotation = Quaternion.AngleAxis(degreesVertical, Camera.main.transform.right);
	}
}
