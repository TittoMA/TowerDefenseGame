using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float turnSpeed = 3.0f;
    public Transform player;
    public Transform aim;
    private Vector3 offsetX;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = new Vector3(0, 4.7f, 6f);
    }

    void LateUpdate()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offsetX;

        transform.position = player.position + offsetX;
        transform.LookAt(aim.position);
        
    }
}
