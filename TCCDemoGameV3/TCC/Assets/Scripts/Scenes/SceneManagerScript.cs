using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public static SceneManagerScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AudioManagerScript.Instance.PlayIntro();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Instância já está em execução");
        }
    }

    public void StartGame()
    {
        //Carrega a cena principal do jogo sem fechar as cenas anteriores
        SceneManager.LoadScene("TCCDemoGame");
        AudioManagerScript.Instance.PlayHelicopterSound();
    }
	
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

}
