using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 3, -5);

    public float rotateSpeed =1.0f;
    public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        /*pivot.transform.position = player.transform.position;
        pivot.transform.parent = player.transform;*/

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the X position of the mouse and rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizontal, 0);

        //Get the y position of the mouse and rotate puivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        //limit up/down
 
        if(pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }
        

        //move the camera based on current rotation of the target
        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.position + (rotation* offset);


        if(transform.position.y < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y -.5f, transform.position.z);
        }

        transform.LookAt(player);

    }
}
