using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBot : MonoBehaviour
{
	public float botHP = 200f;
    public Text enemyText;
    private void Awake()
    {
        enemyText.text = "";
    }

    private void Update()
	{
        enemyText.text = "EnemyBot: " + botHP.ToString();

        if (botHP <= 0)
		{
            StartCoroutine(Blink());
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grasp")
        {
            botHP -= 50f * Time.deltaTime;
        }

        if (other.gameObject.tag == "Orb")
        {
            botHP -= 50f * Time.deltaTime;
        }

        if (other.gameObject.tag == "Ult")
        {
            botHP -= 70f * Time.deltaTime;
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
