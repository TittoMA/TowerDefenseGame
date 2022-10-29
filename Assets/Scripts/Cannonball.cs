using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{

    public float life = 3;
  void Awake() {
    Destroy(gameObject, life);
 }

 private void OnCollisionEnter(Collision collision) {
    if(collision.gameObject.tag == "target")
    Destroy(collision.gameObject);
 }
}
