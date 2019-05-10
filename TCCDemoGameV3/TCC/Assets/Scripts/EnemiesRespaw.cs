using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRespaw : MonoBehaviour{

	public GameObject go_helicoptero;
	float timeRespaw = 2f;
	float lastTimeRespaw;

	// Use this for initialization
	void Start ()
	{
		//Primeiro inimigo
		lastTimeRespaw = Time.time + timeRespaw;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Criação de novos inimigos aleatórios
		if (Time.time > lastTimeRespaw) {

			Vector3 newPos = new Vector3 (transform.position.x + Random.Range (-6f, 6f), transform.position.y + Random.Range (-6f, 6f), 0);
			GameObject newHeli = Instantiate (go_helicoptero, newPos, Quaternion.identity) as GameObject;
			lastTimeRespaw = Time.time + timeRespaw;

		}
	}
}
