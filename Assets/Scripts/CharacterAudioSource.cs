using UnityEngine;

public class CharacterAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip fly;
    [SerializeField] private AudioClip fullPower;
    [SerializeField] private AudioSource audioSource;

    private PlayerController playerController => gameObject.GetComponent<PlayerController>();

    private void Start()
    {
        playerController.isFlying += Fly;
        playerController.isFullPowered += FullPower;
    }

    private void OnDisable()
    {
        playerController.isFlying -= Fly;
        playerController.isFullPowered -= FullPower;
    }

    private void Fly()
    {
        // audioSource.PlayOneShot(fly);
    }

    private void FullPower()
    {
    //    audioSource.PlayOneShot(fullPower, 0.05f);
    }
}
