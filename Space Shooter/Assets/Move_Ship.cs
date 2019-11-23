using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ship : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    public GameObject laser;
    private float cooldown;

    void Update()
    {
    	if (cooldown < 1f)
    		cooldown += 0.08f;
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.right * fixedJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void OnCollisionEnter(Collision hit)
    {
    	if (hit.gameObject.tag == "destroyer")
    		rb.velocity = Vector3.zero;
    }
    public void Shoot()
    {
    	if (cooldown >= 1f)
    	{
	    	Instantiate(laser, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity).transform.SetParent(GameObject.Find("Lasers").transform);
	    	cooldown -= 1f;
	    }
    }
}
