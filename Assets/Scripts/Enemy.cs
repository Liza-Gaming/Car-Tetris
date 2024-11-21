using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] private float lifetime = 5f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.rotation = Quaternion.Euler(0, 180, 0);
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        rb.linearVelocity = Vector3.back * speed;
    }
}

