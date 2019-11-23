using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{
    void Update()
    {
    	GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
    }

    void OnTriggerEnter (Collider hit)
    {
    	if (hit.gameObject.tag == "destroyer")
	    	Destroy(gameObject);
    }
}
