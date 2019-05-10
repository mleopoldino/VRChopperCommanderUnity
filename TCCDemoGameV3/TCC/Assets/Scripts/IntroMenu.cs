using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class IntroMenu : MonoBehaviour {

    public SerialPort porta = new SerialPort("COM3", 9600);

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.Return)){
			SceneManager.LoadScene("TCCDemoGame", LoadSceneMode.Single);
		}
	}
}
