using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyBot : MonoBehaviour
{
	public float botHP = 50f;
    public Text allyText;

    private void Awake()
    {
        allyText.text = "";

    }

    private void Update()
	{
        allyText.text = "AllyBot: " + botHP.ToString();
        
        if(botHP >= 200)
		{
            StartCoroutine(Blink());
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grasp")
        {
            botHP += 70f * Time.deltaTime;
        }

        if (other.gameObject.tag == "Orb")
        {
            botHP += 65f * Time.deltaTime;
        }

        if (other.gameObject.tag == "Ult")
        {
            botHP += 140f * Time.deltaTime;
        }
    }

    IEnumerator Blink()
    {
        this.enabled = false;
        yield return new WaitForSeconds(2f);
        this.enabled = true;
        botHP = 200;
    }
}
