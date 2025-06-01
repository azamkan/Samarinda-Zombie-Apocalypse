using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource helicopterSource;

    [Header("------ Audio Clip -------")]
    public AudioClip background;
    public AudioClip zombie;
    public AudioClip pintu;
    public AudioClip ambilbarang;
    public AudioClip helikopter;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    private float zombieSoundCooldown = 9.0f; // minimal jeda antar zombie sound
    private float lastZombieSoundTime = -1f;

    public void PlayZombieSound()
    {
        if (Time.time - lastZombieSoundTime >= zombieSoundCooldown)
        {
            PlaySFX(zombie);
            lastZombieSoundTime = Time.time;
        }
    }


    public void PlayHelicopterSound()
    {
        helicopterSource.clip = helikopter;
        helicopterSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
