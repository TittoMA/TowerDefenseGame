using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifeDuration = 4f;
    private GameObject hitSound;
    private AudioSource hitSfx;

    void Awake()
    {   
        hitSound = GameObject.FindWithTag("HitSfx");
        hitSfx = hitSound.GetComponent<AudioSource>();
        Destroy(gameObject, lifeDuration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target"){
            hitSfx.Play();
            Destroy(collision.gameObject);
        }
    }
}
