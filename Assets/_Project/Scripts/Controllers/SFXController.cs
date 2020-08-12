using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] onCircleHit;
    public AudioClip[] onWallHit;

    int latestSfx;

    private void OnEnable()
    {
        NW.Game.EventsProvider.onCircleHit += OnCircleSFX;
        NW.Game.EventsProvider.onWallHit += OnWallSFX;
    }

    private void OnDisable()
    {
        NW.Game.EventsProvider.onCircleHit -= OnCircleSFX;
        NW.Game.EventsProvider.onWallHit -= OnWallSFX;
    }

    private void OnWallSFX()
    {
        float randomPitch = UnityEngine.Random.Range(0.7f, 1.3f);
        audioSource.pitch = randomPitch;
        int randomSFX = UnityEngine.Random.Range(0, onWallHit.Length);
        audioSource.PlayOneShot(onWallHit[randomSFX]);
    }

    private void OnCircleSFX()
    {
        float randomPitch = UnityEngine.Random.Range(1f, 1.5f);
        audioSource.pitch = randomPitch;
        //int randomSFX = UnityEngine.Random.Range(0, onCircleHit.Length);
        audioSource.PlayOneShot(onCircleHit[latestSfx]);
        latestSfx++;
        if (latestSfx >= onCircleHit.Length)
        {
            latestSfx = 0;
        }
    }
}
