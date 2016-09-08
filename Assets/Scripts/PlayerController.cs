using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
		float moveHorizontalP2 = Input.GetAxis ("P2Horizontal");
		float moveVerticalP2 = Input.GetAxis ("P2Vertical");

		Vector3 movementP2 = new Vector3 (moveHorizontalP2, 0.0f, moveVerticalP2);

		rb.AddForce (movementP2 * speed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.LeftShift) && rb.transform.position.y <= 0.5f) {
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
		if (count >= 7) 
		{
			winText.text = "Player 1 Wins!";
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0,Screen.height - 50,100,50));
		GUILayout.FlexibleSpace();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();

		if (GUILayout.Button("Restart")) {
			Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.EndArea();
	}
}