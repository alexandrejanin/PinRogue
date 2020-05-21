using Sirenix.OdinInspector;
using UnityEngine;

public class TNT : Weapon {
    [SerializeField, Min(0)] private float range = 3;
    [SerializeField, Min(0)] private float strength = 10;

    [Button]
    public override void Hit(Hurtable hurtable) {
        foreach (var rigidbody2D in FindObjectsOfType<Rigidbody2D>()) {
            if (rigidbody2D.gameObject == gameObject)
                continue;

            if (Vector3.Distance(transform.position, rigidbody2D.position) < range) {
                var direction = (rigidbody2D.position - (Vector2) transform.position).normalized;
                var normalizedDistance = (rigidbody2D.position - (Vector2) transform.position).magnitude / range;
                var force = strength * (1 / normalizedDistance);
                rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}