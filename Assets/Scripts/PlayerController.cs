using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		//player 1
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);

		if (Input.GetKeyDown ("space") && rb.transform.position.y <= 0.5f) {
			Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);

			rb.AddForce (jump);
		}

		//player 2
		float moveHorizontalP2 = Input.GetAxis ("Player 2 Horizontal");
		float moveVerticalP2 = Input.GetAxis ("Player 2 Vertical");

		Vector3 movementP2 = new Vector3 (moveHorizontalP2, 0.0f, moveVerticalP2);

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
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}