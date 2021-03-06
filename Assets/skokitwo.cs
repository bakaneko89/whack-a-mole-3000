﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class skokitwo : MonoBehaviour {

	public bool onGround;
	private Rigidbody rbody;
	private bool canGetPoint;
	public static int mnoznik;
	public static int liczmnoznik;
	public Texture[] textures;

	// Use this for initialization
	void Start () {
		onGround = true;
		canGetPoint = false;
		rbody = GetComponent<Rigidbody> ();
		Invoke ("Skok", Random.Range (0, 8));
		mnoznik = 1;
		GetComponent<Renderer>().material.mainTexture = textures [0];

	}

	// Update is called once per frame
	void Update () {		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Ground")) {
			onGround = true;
			GetComponent<Renderer>().material.mainTexture = textures [0];
			Invoke ("Skok", Random.Range (3, 8));
		}
		if (col.gameObject.CompareTag ("mlotek")) {
			if (!onGround & canGetPoint) {
				punktacja.punkty += 1*mnoznik;
				canGetPoint = false;
				liczmnoznik += 1;
				if (liczmnoznik > 5) {
					mnoznik = mnoznik * 2;
					liczmnoznik = 0;
				}
				GetComponent<Renderer>().material.mainTexture = textures [1];
			}		

		}
	}

	void Skok(){
		if (onGround) {
			rbody.velocity = new Vector3 (0f, 7f, 0f);
			onGround = false;
			canGetPoint = true;
			}
	}

}