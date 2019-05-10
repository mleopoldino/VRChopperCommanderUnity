using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoviment : MonoBehaviour {

	public float speed = 10;
	public Image img_Fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		//Movimentação da camera - Limites
		if (horizontal > 0 && transform.position.x > 9.8f)
			return;

		if (horizontal < 0 && transform.position.x < -9.8f)
			return; 

		if (vertical > 0 && transform.position.y > 9.5f)
			return;

		if (vertical < 0 && transform.position.y < -9.5f)
			return; 

		transform.Translate (new Vector3 (horizontal, vertical, 0) * speed * Time.deltaTime);

		//Controle de disparos
		if (Input.GetKeyDown (KeyCode.Space)) {
			img_Fire.color = new Color(255,255,255,255);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			img_Fire.color = new Color(255,255,255,0);
		}

	}
}
