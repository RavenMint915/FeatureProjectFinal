using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCast : MonoBehaviour
{
    private float dmgAmmo = 200, healAmmo = 300;
    private float speed = 10f;
  
    private void Update()
    {
        transform.position += speed * Vector3.forward * Time.deltaTime;

        if(dmgAmmo <= 0 || healAmmo <= 0)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ally")
        {
            healAmmo -= 65f * Time.deltaTime;
        }

        if(other.gameObject.tag == "Enemy")
        {
            dmgAmmo -= 50f * Time.deltaTime;
        }
        speed = 4f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(this);
        }
    }
}
