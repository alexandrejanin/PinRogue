using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject[] enemies;
    [SerializeField, Min(0)] private int enemyAmount = 10;
    [SerializeField] private Bounds bounds;

    private void Awake() {
        for (var i = 0; i < enemyAmount; i++) {
            var position = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );
            Instantiate(
                enemies[Random.Range(0, enemies.Length)],
                position,
                Quaternion.Euler(0, 0, Random.Range(0, 360))
            );
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}