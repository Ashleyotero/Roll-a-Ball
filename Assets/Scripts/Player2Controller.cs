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

		if(Input.GetKeyDown(KeyCode.A)) //left
		{
			Vector3 movement = Vector3.left;
			rb.AddForce (movement * speed);
		}
		if(Input.GetKeyDown(KeyCode.D)) //right
		{
			Vector3 movement = Vector3.right;
			rb.AddForce (movement * speed);
		}
		if(Input.GetKeyDown(KeyCode.S)) //down
		{
			Vector3 movement = Vector3.down;
			rb.AddForce (movement * speed);
		}
		if(Input.GetKeyDown(KeyCode.A)) //up
		{
			Vector3 movement = Vector3.up;
			rb.AddForce (movement * speed);
		}

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

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