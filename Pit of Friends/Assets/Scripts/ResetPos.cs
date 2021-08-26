using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    // Update is called once per frame
    public GameObject ball;
    public GameObject respawn;
    void Update()
    {
        if(ball.transform.position.y < -1){
            ball.transform.position = respawn.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
