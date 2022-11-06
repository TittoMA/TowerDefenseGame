using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public float horizontalRotationSpeed = 3f;
    public float verticalRotationSpeed = 1.5f;
    public float shotForce = 1200f;
    public float reloadTime = 1.5f;
    public float fireRate = 1f;
    float nextFire;
    public int maxAmmo = 4;
    public int currentAmmo;

    public Rigidbody cannonBall;
    public Transform shotPoint;
    public Transform cannon;
    public GameObject explosion;
    public AudioSource shootSound;
    public Text ammoText;

    void Start(){
        currentAmmo = maxAmmo;
        ammoText.text = currentAmmo.ToString();
    }

    private void Update()
    {
        if(!GameState.gameIsPaused){

            if(currentAmmo > 0) {
                if (Input.GetButtonUp("Fire1"))
                {
                    Shoot();
                }
            } else {
                StartCoroutine(Reload());
            }
        }  

        // Rotasi horizontal senjata 
        float horizontalRotation = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, horizontalRotation * horizontalRotationSpeed, 0));

        // Rotasi vertikal senjata
        float verticalRotation = Input.GetAxis("Vertical");
        float xRotation =  verticalRotation * verticalRotationSpeed * -1f;
        Vector3 rotation = new Vector3(xRotation, 0, 0);

        if(cannon.rotation.eulerAngles.x + xRotation <= 90 && cannon.rotation.eulerAngles.x + xRotation >= 0){
            cannon.rotation = Quaternion.Euler(cannon.rotation.eulerAngles + rotation);
        }

        // Debug.Log("ANGLESS " + cannon.rotation.eulerAngles.x);
    }

    void Shoot(){

        if(Time.time > nextFire){
            nextFire = Time.time + fireRate;

            Rigidbody shot = Instantiate(cannonBall, shotPoint.position, shotPoint.rotation) as Rigidbody;
            shot.AddForce(shotPoint.forward * shotForce);
            shootSound.Play();

            // Added explosion for added effect
            Destroy(Instantiate(explosion, shotPoint.position, shotPoint.rotation), 2);

            currentAmmo--;
            ammoText.text = currentAmmo.ToString();
        }

        
    }

    IEnumerator Reload(){
        Debug.Log("Reloading...");

        ammoText.text = "Reloading...";
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        ammoText.text = currentAmmo.ToString();
    }

}
