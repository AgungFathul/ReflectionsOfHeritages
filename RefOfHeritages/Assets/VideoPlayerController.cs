using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float playRadius = 5f;
    public AudioSource audioSource;
    public float lowVolume = 0.05f;
    public float highVolume = 1f;

    private bool isPlayerInRange = false;
    private bool isVideoActive = false;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (isPlayerInRange && !isVideoActive)
        {
            PlayVideo();
        }

        if (isVideoActive)
        {
            AdjustVolume();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isVideoActive)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isVideoActive)
        {
            isPlayerInRange = false;
        }
    }

    private void PlayVideo()
    {
        videoPlayer.Play();
        audioSource.volume = highVolume;
        isVideoActive = true;
    }

    private void AdjustVolume()
    {
        if (isPlayerInRange)
        {
            audioSource.volume = highVolume;
        }
        else
        {
            audioSource.volume = lowVolume;
        }
    }
}
