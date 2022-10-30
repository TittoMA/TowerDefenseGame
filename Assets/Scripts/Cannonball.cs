using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifeDuration = 4f;

    void Awake()
    {
        Destroy(gameObject, lifeDuration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target"){
            Destroy(collision.gameObject);
        }
    }
}
