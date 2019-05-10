using Unity.Entities;
using UnityEngine;

public class Respaw : MonoBehaviour {

    public float timeRespaw = 2f;
    public float lastTimeRespaw = 0;

    // Update is called once per frame
    void Update()
    {
        lastTimeRespaw += 1f * Time.deltaTime;

        if (lastTimeRespaw >= timeRespaw)
        {
            //Instanciando aleatóriamente novos inimigos
            Vector3 newPosition = new Vector3(transform.position.x + Random.Range(-6f, 6f), transform.position.y + Random.Range(-6f, 6f), 0);
            GameObject Helicopter = Object.Instantiate(Resources.Load<GameObject>(@"Prefabs/Helicoptero"), newPosition, Quaternion.identity) as GameObject;

            var HelicopterInscancies = GameObject.FindGameObjectsWithTag("Enemie");
            Helicopter.GetComponent<SpriteRenderer>().sortingOrder = 100 - HelicopterInscancies.Length;

           lastTimeRespaw = 0f;
        }
    }
}
