using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioticGrasp : MonoBehaviour
{
    public float healAmmo;

    private void Awake()
    {
        healAmmo = 156f;
    }

    private void Update()
    {
        if(healAmmo <= 0)
        {
            StartCoroutine(GraspTimer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ally")
        {
            healAmmo -= 20f * Time.deltaTime;
        }
    }

    private IEnumerator GraspTimer()
    {
        yield return new WaitForSeconds(5f);
        healAmmo = 156f;
    }
}
