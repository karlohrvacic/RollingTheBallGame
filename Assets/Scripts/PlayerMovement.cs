using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;

	public float forwardForce = 1000f;
	public float sidewaysForce = 100f;

	void FixedUpdate ()
	{
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))
		{
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
		}

		if (rb.position.y < -10f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}