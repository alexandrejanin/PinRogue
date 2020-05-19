using UnityEngine;

public class Hurtable : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        var weapon = other.collider.GetComponentInParent<Weapon>();
        if (weapon) {
            weapon.Hit(this);
            Destroy(gameObject);
        }
    }
}