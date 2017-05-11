using UnityEngine;

public class WeaponController : MonoBehaviour {

    [Header("Components")]
    [SerializeField] GameObject ProjectilePrefab;

    [Header("Parameters")]
    [SerializeField] float Force = 1f;
	
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
            GameObject projectile = Instantiate(ProjectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;

            Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.AddForce(projectile.transform.forward * Force);
        }
	}
}
