using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score: MonoBehaviour  {

    public static Score Instance;
    public GameObject Alvo;
    public GameObject[] Enemies;
    public int PlayerPoints;
    public int Damage = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Instância já está em execução");
        }
    }

    private void Start()
    {
        Alvo = GameObject.FindGameObjectWithTag("alvo");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("TCCDemoGame"))
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemie");

            foreach (var enemie in Enemies)
            {
                if (enemie.GetComponent<BoxCollider2D>().IsTouching(Alvo.GetComponent<BoxCollider2D>()))
                {
                    Destroy(enemie);
                    PlayerPoints++;
                    GameObject.FindWithTag("pontos").GetComponent<TextMeshProUGUI>().text = PlayerPoints.ToString();
                    AudioManagerScript.Instance.PlayExplosionSound();

                    GameObject newExplosion = Instantiate(Resources.Load<GameObject>("Prefabs/explosion"), enemie.transform.position, Quaternion.identity) as GameObject;
                    Destroy(newExplosion, 0.2f);
                }
            }

            GameObject.FindWithTag("damage").GetComponent<TextMeshProUGUI>().text = Damage.ToString();

            if (Damage > 9)
            {
                Debug.Log("Destruído");
                SceneManagerScript.Instance.GameOver();
            }
        }
    }
}
