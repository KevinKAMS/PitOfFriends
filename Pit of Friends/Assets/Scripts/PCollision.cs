using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PCollision : NetworkBehaviour
{
    private GameObject player;
    void OnCollisionEnter(Collision c){
        if(c.gameObject.tag == "Player"){
             Debug.Log("Funcionou");
            player = c.gameObject;
        }
    }
    [ServerCallback]
    void OnTriggerEnter (Collider c)
    {
        Debug.Log(c.gameObject.tag);
        if(c.gameObject.tag == "goal"){
            addPoint(player);            
        }
    }

    void addPoint(GameObject player){
        player.GetComponent<PlayerScoreB>().score += 1; 
    }

}
