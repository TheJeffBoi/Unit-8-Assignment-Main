using UnityEngine;

public enum SoundType
{
    ConcreteFootsteps,
    HolsterPistol,
    TrainAmbiance,
    MetalFootsteps,
    PlayerGunshot,
    EnemyGunshot,
    StationAmbiance,
    Damage,
    DoorOpen,
    Reload
}

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] soundList;
    static AudioManager Instance;
    AudioSource audioSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.soundList[(int)sound], volume);
        //Instance.audioSource.Play();
    }

    public static void StopSound(SoundType sound)
    {
        Instance.audioSource.Stop();
    }
}
