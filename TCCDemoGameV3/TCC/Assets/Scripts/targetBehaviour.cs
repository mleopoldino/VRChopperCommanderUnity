using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class targetBehaviour : MonoBehaviour {

	BoxCollider2D boxCol;
	public GameObject go_explosion;
	public AudioClip explosion;
	public AudioClip fire;
	public AudioSource Audio;
	public int point;
	public Text placar;


	// Use this for initialization
	void Start () {
		boxCol = GetComponent<BoxCollider2D>();
		point = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			boxCol.enabled = true;
			
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			boxCol.enabled = false;

		}

	}


	void OnTriggerEnter2D(Collider2D other) {

		Destroy (other.gameObject);

		point++;

	    GameObject.FindWithTag ("pontos").GetComponent <Text> ().text = point.ToString ();


		Audio = GetComponent <AudioSource>();

		GameObject newExplosion = Instantiate (go_explosion,other.transform.position,Quaternion.identity) as GameObject;
		Destroy (newExplosion,0.2f);

    }


}
