using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour
{
    public AudioClip menuMusic;  // Assign your music clip via the Inspector
    private AudioSource audioSource;

    void Awake()
    {
        Debug.Log("MainMenuMusic Awake called");

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("MainMenuMusic: No AudioSource component found on " + gameObject.name);
            return;
        }
        else
        {
            Debug.Log("AudioSource found");
        }

        if (menuMusic == null)
        {
            Debug.LogError("MainMenuMusic: Menu Music clip not assigned in the Inspector!");
            return;
        }
        else
        {
            Debug.Log("Menu music clip is assigned: " + menuMusic.name);
        }

        // Set up the audio source
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.3f;

        Debug.Log("MainMenuMusic: Starting to play music");
        audioSource.Play();
    }

    // Function to fade out and stop, callable from a button
    public void FadeOutAndStop(float fadeDuration)
    {
        StartCoroutine(FadeOutCoroutine(fadeDuration));
    }

    private IEnumerator FadeOutCoroutine(float fadeDuration)
    {
        float startVolume = audioSource.volume;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }
        audioSource.volume = 0f;
        audioSource.Stop();
    }
}
