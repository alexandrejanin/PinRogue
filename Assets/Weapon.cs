using UnityEngine;

public class Weapon : MonoBehaviour {
    public virtual void Hit(Hurtable hurtable) {
        Destroy(hurtable.gameObject);
    }
}