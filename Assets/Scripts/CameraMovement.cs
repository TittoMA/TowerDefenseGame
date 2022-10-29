using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float turnSpeed = 2.0f;
    public Transform player;

    private Vector3 offsetX;
    // private Vector3 offsetY;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = new Vector3(player.position.x, player.position.y+2.5f, player.position.z + 12.57f);
        // offsetY = new Vector3 (player.position.x, player.position.y, player.position.z - 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = player.transform.position + new Vector3(0, 3, -5);
    }

    void LateUpdate()
     {
        offsetX = Quaternion.AngleAxis (Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offsetX;
        // offsetY = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;

        transform.position = player.position + offsetX ; // offsetY;
        transform.LookAt(player.position);

        // transform.RotateAround(player.transform.position, transform.up, Input.GetAxis("Mouse X") * turnSpeed);

        // transform.RotateAround(player.transform.position, transform.right, Input.GetAxis("Mouse Y") * turnSpeed);
     }
}
