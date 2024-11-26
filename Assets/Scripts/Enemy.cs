using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("The speed at which the enemy moves.")]
    [SerializeField] private float speed = 3f;

    [Tooltip("Time in seconds before the enemy is destroyed automatically.")]
    [SerializeField] private float lifetime = 5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody component missing from Enemy.");
        }

        // Be destroyed after a set lifetime
        Destroy(gameObject, lifetime);
    }

    // FixedUpdate is called at a fixed time interval
    private void FixedUpdate()
    {
        // Set the enemy's rotation to face backwards
        transform.rotation = Quaternion.Euler(0, 180, 0);

        // Apply a backward force to the Rigidbody to move the enemy (Axis z)
        if (rb != null)
        {
            rb.linearVelocity = Vector3.back * speed;
        }
    }
}