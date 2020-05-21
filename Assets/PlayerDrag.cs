using UnityEngine;

public class PlayerDrag : MonoBehaviour {
    [SerializeField, Min(0)] private float forceMultiplier = 10f;
    [SerializeField, Min(0)] private float maxForce = 3f;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private LineRenderer lineRenderer;

    private Vector2? dragStartPos;

    private void Awake() {
        lineRenderer.startColor = new Color(1, 1, 1, 0.9f);
        lineRenderer.endColor = new Color(1, 1, 1, 0);
    }

    private void Update() {
        if (rigidbody2D.velocity.magnitude > 0.01f)
            return;

        rigidbody2D.velocity = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
            dragStartPos = Input.mousePosition;

        if (dragStartPos == null)
            return;

        var worldOffset = Camera.main.ScreenToWorldPoint(dragStartPos.Value) -
                          Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldOffset = Vector3.ClampMagnitude(worldOffset, maxForce);

        lineRenderer.enabled = Input.GetMouseButton(0);
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 1));
        lineRenderer.SetPosition(1,
            new Vector3((transform.position + worldOffset).x, (transform.position + worldOffset).y, 1));

        transform.up = worldOffset;

        if (Input.GetMouseButtonUp(0)) {
            dragStartPos = null;
            rigidbody2D.AddForce(forceMultiplier * worldOffset, ForceMode2D.Impulse);
            rigidbody2D.AddTorque(forceMultiplier * worldOffset.magnitude);
        }
    }
}