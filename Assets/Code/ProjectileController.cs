using UnityEngine;

public class ProjectileController : MonoBehaviour {

    [Header("Components")]
    [SerializeField] ParticleSystem ExplosionParticleSystemPrefab;

    void OnCollisionEnter(Collision collision) {
        ParticleSystem explosion = Instantiate(ExplosionParticleSystemPrefab);
        explosion.transform.position = gameObject.transform.position;

        GameObject.Destroy(gameObject);
    }
}