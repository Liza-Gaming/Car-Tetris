using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Control the player with defined keyboard buttons")]
    public InputAction PlayerControls;

    [SerializeField]
    [Tooltip("Movement speed in meters per second")]
    private float _speed = 5f;

    [SerializeField]
    [Tooltip("The maximum health the player can have")]
    public int maxHealth = 3;

    public static int currentHealth = 3; //The current health of the player.

    private Rigidbody rb;

    // Direction vector to apply movement.
    Vector3 moveDir = Vector3.zero;

    bool isAlive;

    void OnEnable()
    {
        PlayerControls.Enable();
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = PlayerControls.ReadValue<Vector2>();
        moveDir = new Vector3(inputVector.x, 0, 0); // Move only along X-axis
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * _speed; // 'speed' should be a predefined float value
    }

    // Handles collisions with other objects like enemies, points, and lives.
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy") && currentHealth > 0)
        {

            Destroy(other.gameObject);
            TakeDamage(1);
            ScoreManager.instance.RemoveHeart();
        }

        if (other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            ScoreManager.instance.AddPoint();

        }

        if (other.gameObject.CompareTag("Live"))
        {
            if (currentHealth < maxHealth)
            {
                ScoreManager.instance.AddHeart();

            }
            Destroy(other.gameObject);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //  Reduces the player's health by the specified damage amount.
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

}
