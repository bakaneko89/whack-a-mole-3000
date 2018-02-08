using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skakanie : MonoBehaviour {
	public bool onGround;
	private Rigidbody rbody;
	GameObject[] Skoczki;
	GameObject Skoczek;

	// Use this for initialization
	void Start () {
		
		Skoczki = GameObject.FindGameObjectsWithTag ("Skoczki");
		foreach (GameObject Skoczek in Skoczki){
			onGround = true;
			rbody = GetComponent<Rigidbody> ();}

		Invoke ("WybierzSkoczka", 3);
	}
	
	// Update is called once per frame
	void Update () {		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag("Ground"))
			onGround = true;
		WybierzSkoczka ();			
	}

	void Skok(GameObject Skoczek){
		if (onGround) {
			rbody.velocity = new Vector3 (0f, 5f, 0f);
			onGround = false;

		}
	}
	void WybierzSkoczka(){
		Skok(Skoczki [Random.Range (0, Skoczki.Length - 1)]);
	}
}