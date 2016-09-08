using UnityEngine;
using System.Collections;

public class FindMidPoint : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	private Vector3 midpoint;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {

		midpoint = (player1.gameObject.transform.position + player2.gameObject.transform.position) * .5f;
		transform.position = midpoint;


	}
}