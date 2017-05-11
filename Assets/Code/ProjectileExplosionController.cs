using UnityEngine;

public class ProjectileExplosionController : MonoBehaviour {

    [Header("Components")]
    [SerializeField] ParticleSystem ParticleSystem;

    void Update() {
		if (!ParticleSystem.isPlaying) {
            GameObject.Destroy(ParticleSystem.gameObject);
        }
	}
}
