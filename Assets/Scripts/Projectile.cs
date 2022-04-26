using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damageDone;
    public float moveSpeed;
    public float lifespan;
    public Rigidbody rb;

    // Start is called before the first frame update
    private void Awake()
    {
        //Load components
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //destroy after lifespan
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }
        Debug.Log("Collides with " + other.name);
        Destroy(gameObject);
    }
}
