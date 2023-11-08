using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform target;
    public GameObject player;

    void OnTriggerEnter(Collider other){
        player.transform.position = target.transform.position;
    }
}
