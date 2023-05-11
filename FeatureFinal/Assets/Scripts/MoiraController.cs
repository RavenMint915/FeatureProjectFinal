using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoiraController : MonoBehaviour
{
	[SerializeField]
	private float speed = 5.5f;

	[HideInInspector]
	public bool orbSpawn = false;

	public GameObject bioticHeal, bioticDmg, orbHeal, orbDmg, ultBeam;

	private Rigidbody rigidBody;
	public PlayerInputActions playerInput;

	private void Awake()
	{
		playerInput = new PlayerInputActions();
		playerInput.Enable();
		rigidBody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector2 moveVec = playerInput.BasicMovement.Movement.ReadValue<Vector2>();
		transform.Translate(new Vector3(moveVec.x, 0, moveVec.y) * speed * Time.deltaTime);

	}

	private void Update()
	{
		
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (context.performed && this.gameObject.transform.position.y <= 2)
		{
			rigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
		}
	}

	public void BioticGrasp(InputAction.CallbackContext context)
	{
		GameObject tempGrasp;
		if (context.performed)
		{
			tempGrasp = Instantiate(bioticDmg,this.gameObject.transform.position, this.gameObject.transform.rotation);
		}
		if (context.canceled)
		{
			tempGrasp = GameObject.FindWithTag("Grasp");
            if (tempGrasp)
            {
				Destroy(tempGrasp);
            }
		}
	}

	public void BioticHeal(InputAction.CallbackContext context)
	{
		GameObject tempHeal;
		if (context.performed)
		{
			tempHeal = Instantiate(bioticHeal, this.gameObject.transform.position, this.gameObject.transform.rotation);
		}
		if (context.canceled)
		{
			tempHeal = GameObject.FindWithTag("Grasp");
			if (tempHeal)
			{
				Destroy(tempHeal);
			}
		}
	}

	public void OrbHeal(InputAction.CallbackContext context)
	{
		GameObject tempHeal;
		if (context.performed)
		{
			tempHeal = Instantiate(orbHeal, this.gameObject.transform.position, this.gameObject.transform.rotation);
			StartCoroutine(OrbTimerHeal(tempHeal));
		}
	}

	public void OrbDmg(InputAction.CallbackContext context)
	{
		GameObject tempDmg;
		if (context.performed)
		{
			tempDmg = Instantiate(orbDmg, this.gameObject.transform.position, this.gameObject.transform.rotation);
			StartCoroutine(OrbTimerDmg(tempDmg));
		}
	}

	public void Coalescence(InputAction.CallbackContext context)
	{
		GameObject tempUlt;
		if (context.performed)
		{
			tempUlt = Instantiate(ultBeam, this.gameObject.transform.position, this.gameObject.transform.rotation);
			StartCoroutine(CoalescenceTimer(tempUlt));
		}
	}

	public void Fade(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			speed = 19.25f;
		}
		if (context.canceled)
		{
			speed = 5.5f;
			StartCoroutine(FadeTimer());
		}

	}

	public IEnumerator FadeTimer()
	{
		speed = 5.5f;
		yield return new WaitForSeconds(7f);
		speed = 5.5f;
	}

	public IEnumerator OrbTimerHeal(GameObject other)
	{
		orbSpawn = true;
		yield return new WaitForSeconds(7f);
		if (other)
		{
			Destroy(other);
		}
		orbSpawn = false;
	}

	public IEnumerator OrbTimerDmg(GameObject other)
	{
		orbSpawn = true;
		yield return new WaitForSeconds(7f);
		if (other)
		{
			Destroy(other);
		}
		orbSpawn = false;
	}

	public IEnumerator CoalescenceTimer(GameObject other)
    {
		yield return new WaitForSeconds(8f);
        if (other)
        {
			Destroy(other);
		}
    }
}
