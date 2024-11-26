using UnityEngine;

// Used ChatGpt
// I added PlayerPos to repeat when it reaching the player
public class RoadScroll : MonoBehaviour
{
    [Tooltip("The speed at which the road moves towards the player.")]
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] public Vector3 PlayerPos;

    private Vector3 startPosition;
    private float repeatLength;

    void Start()
    {
        startPosition = transform.position; // Record the initial start position.
        repeatLength = GetComponent<Renderer>().bounds.size.z + PlayerPos.z; // Set the length after which the texture repeats.
    }

    void Update()
    {
        // Move the road backward to simulate forward movement.
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // If the road has moved back its length, reset its position (Optional: if creating an endless loop)
        if (transform.position.z < startPosition.z - repeatLength)
        {
            transform.position = startPosition;
        }
    }
}