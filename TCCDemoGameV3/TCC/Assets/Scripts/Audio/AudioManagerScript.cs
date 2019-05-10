using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour {

    //Criamos uma propriedade estática chamada Instance na qual será a única instância
    //do nosso Objeto, atribuimos private set para que ela só possa ser alterada dentro da
    //da própria instância
    public static AudioManagerScript Instance { get; private set; }
    private AudioSource BackingTrackSoundSource;
    private AudioSource HelicopterSoundSource;
    private AudioSource AttackSoundSource;
    private AudioSource ExplosionSoundSource;
    public float ChangeIntroVolume = 0;
    public float ChangeHelicopterVolume = 0;
    public float AttackVolume = 3;
    public float ExplosionVolume = 0.7f;
    public float AttackVelocitySound = 1.5f;
    public bool isPlayingHelicopterSound;
    public bool isAttacking;

    //Método Awake é o primeiro código a ser executado pela nossa instância
    private void Awake()
    {
        //Se ao inicializar a instância estiver vazia 
        //atribuimos o objeto atual a nossa instância e definimos que o objeto não
        //poderá ser destruido
        if (Instance == null)
        {
            Instance = this;          
            DontDestroyOnLoad(gameObject);

            //Adicionando as trilhas de som
            BackingTrackSoundSource = gameObject.AddComponent<AudioSource>();
            HelicopterSoundSource = gameObject.AddComponent<AudioSource>();
            AttackSoundSource = gameObject.AddComponent<AudioSource>();
            ExplosionSoundSource = gameObject.AddComponent<AudioSource>();
            BackingTrackSoundSource.clip = Resources.Load<AudioClip>("Sounds/BackgroundTheme");
            HelicopterSoundSource.clip = Resources.Load<AudioClip>("Sounds/HelicopterSoundEffect");
            AttackSoundSource.clip = Resources.Load<AudioClip>("Sounds/MachineGunSoundEffect");
            ExplosionSoundSource.clip = Resources.Load<AudioClip>("Sounds/ExplosionSoundEffect");
        }
        else
        {
            //Se a instância já estiver em execução, destruímos qualquer objeto que tentar
            //instânciar novamente
            Destroy(gameObject);
            Debug.Log("Não é possível criar uma nova instância do objeto: " + this.name);
        }
    }

    public void PlayIntro()
    {
        BackingTrackSoundSource.Play();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "TCCDemoGame")
        {
            BackingTrackSoundSource.volume += ChangeIntroVolume * Time.deltaTime;
         
            PlayAttackSound();
            HelicopterSoundFadeIn();
        }
    }

    public void PlayHelicopterSound()
    {
        if (!isPlayingHelicopterSound)
        {
            HelicopterSoundSource.volume = 0;
            HelicopterSoundSource.loop = true;
            HelicopterSoundSource.Play();
            isPlayingHelicopterSound = true;
        }
    }

    public void HelicopterSoundFadeIn()
    {
        if (isPlayingHelicopterSound)
        {

            if (HelicopterSoundSource.time > 7)
                HelicopterSoundSource.time = 2;

            if (HelicopterSoundSource.volume < 2)
            {
                HelicopterSoundSource.volume += ChangeHelicopterVolume * Time.deltaTime;
            }

            if (HelicopterSoundSource.volume > 0.4f)
            {
                HelicopterSoundSource.volume = 0.4f;
            }
        }
    }

    public void PlayAttackSound()
    {
        AttackSoundSource.loop = false;
        AttackSoundSource.volume = AttackVolume;
        AttackSoundSource.pitch = AttackVelocitySound;
      
        if (isAttacking)
        {
            if (!AttackSoundSource.isPlaying)
            {
                AttackSoundSource.time = 0.200f;
                AttackSoundSource.Play();
            }
        }
        else
        {
            AttackSoundSource.Stop();
        }
    }

    public void PlayExplosionSound()
    {
        ExplosionSoundSource.volume = ExplosionVolume;
        ExplosionSoundSource.Play();
    }

    public void StopAllSounds()
    {
        HelicopterSoundSource.Stop();
    }

}
