using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;

	public Text winText;

	private int count;
	private Rigidbody rb;
		 
	void Start(){ // called when the game is activated , usually the first frame of our script 
		count = 0 ;
		winText.text = "";
		SetCountText ();
		rb = GetComponent<Rigidbody>();
	
	}
	void FixedUpdate(){//is called just before doing any physics calculations 
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed );

	}

	void OnTriggerEnter(Collider other) {//other object is compared for tag . this function is connected to the collider sphere information 
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();	

		}
	}
	void SetCountText()
	{
		countText.text = "Count : " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win !";
		}

	}
}
 