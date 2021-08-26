using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class GoalCollision : MonoBehaviour
{
    public GameObject respawn;
    void OnTriggerEnter (Collider c)
    {
        Debug.Log(c.gameObject.tag);
        if(c.gameObject.tag == "ball"){ 
            c.transform.position = respawn.transform.position;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
    }
}
