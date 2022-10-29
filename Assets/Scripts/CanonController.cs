using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    // Start is called before the first frame update
     public float rotationSpeed = 1;
    private void Update()
    {
        
        float VericalRotation = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + 
            new Vector3(VericalRotation * rotationSpeed * -1f, 0, 0));
    }
}
