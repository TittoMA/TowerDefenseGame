using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 3;
    public float ShotForce = 1100f;

    public Rigidbody Cannonball;
    public Transform ShotPoint;

    public GameObject Explosion;
    private void Update()
    {
        float HorizontalRotation = Input.GetAxis("Horizontal");
      

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + 
            new Vector3(0, HorizontalRotation * rotationSpeed, 0));

        if (Input.GetButtonUp("Fire1"))
        {
           Rigidbody shot = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation) as Rigidbody;
           shot.AddForce(ShotPoint.forward * ShotForce);
               // Added explosion for added effect
         Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);
           
            // Shake the screen for added effect
        }
      

    }


}
