using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float minSpeed = 4f, maxSpeed = 7f;
    private float moveSpeed;
    private Rigidbody rb;
    private Vector3 movement;
    private GameObject target;
    public GameObject breakEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("EnemyTarget");
        rb = this.GetComponent<Rigidbody>();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTarget" || collision.gameObject.tag == "Bullet"){
            Destroy(Instantiate(breakEffect, transform.position, transform.rotation), 2);
        }
    }
    
}
