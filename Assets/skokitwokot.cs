using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class skokitwokot : MonoBehaviour {

	public bool onGround;
	private Rigidbody rbody;
	private bool canGetPoint;
	public Texture[] textures;

	// Use this for initialization
	void Start () {
		onGround = true;
		canGetPoint = false;
		rbody = GetComponent<Rigidbody> ();
		Invoke ("Skok", Random.Range (3, 8));
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
				punktacja.punkty -= 1;
				if (skokitwo.mnoznik > 1)
					skokitwo.mnoznik = skokitwo.mnoznik / 2;
				else
					skokitwo.mnoznik = 1;
				skokitwo.liczmnoznik = 0;
				canGetPoint = false;
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