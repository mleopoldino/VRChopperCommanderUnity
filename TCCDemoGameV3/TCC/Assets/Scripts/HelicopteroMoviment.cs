using UnityEngine;

public class HelicopteroMoviment : MonoBehaviour {

    float speed = 0.05f;
    public int tamanho = 0;

	// Update is called once per frame
	void Update ()
	{
		//Efeito da aproximação dos Inimigos
		transform.localScale += new Vector3 (1, 1, 0) * Time.deltaTime * speed;
		tamanho++;
	}
}
