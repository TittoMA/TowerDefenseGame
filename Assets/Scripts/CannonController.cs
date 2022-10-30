using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float horizontalRotationSpeed = 3f;
    public float verticalRotationSpeed = 1.5f;
    public float shotForce = 1200f;

    public Rigidbody cannonBall;
    public Transform shotPoint;
    public Transform cannon;
    public GameObject explosion;

    private void Update()
    {
         if(!GameState.gameIsPaused){
            if (Input.GetButtonUp("Fire1"))
            {
                Rigidbody shot = Instantiate(cannonBall, shotPoint.position, shotPoint.rotation) as Rigidbody;
                shot.AddForce(shotPoint.forward * shotForce);

                // Added explosion for added effect
                Destroy(Instantiate(explosion, shotPoint.position, shotPoint.rotation), 2);
            }
        }  

        // Rotasi horizontal senjata 
        float horizontalRotation = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, horizontalRotation * horizontalRotationSpeed, 0));

        // Rotasi vertikal senjata
        float verticalRotation = Input.GetAxis("Vertical");
        float xRotation =  verticalRotation * verticalRotationSpeed * -1f;
        Vector3 rotation = new Vector3(xRotation, 0, 0);

        if(cannon.rotation.eulerAngles.x + xRotation <= 110 && cannon.rotation.eulerAngles.x + xRotation >= 0){
            cannon.rotation = Quaternion.Euler(cannon.rotation.eulerAngles + rotation);
        }

        // Debug.Log("ANGLESS " + cannon.rotation.eulerAngles.x);
    }

}
