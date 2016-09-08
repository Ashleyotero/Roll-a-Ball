using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Controller : MonoBehaviour {

	public float speed;
	public Text count2Text;
	public Text win2Text;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		win2Text.text = "";
	}

	void FixedUpdate ()
	{
		//player 2
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);

		if (Input.GetKeyDown ("space") && rb.transform.position.y <= 0.5f) {
			Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);

			rb.AddForce (jump);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		count2Text.text = "P2 Count: " + count.ToString ();
		if (count >= 7) 
		{
			win2Text.text = "Player 2 Wins!";
		}
	}
}