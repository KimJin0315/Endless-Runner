using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource effectAudioSource;
    [SerializeField] AudioSource sceneryAudioSource;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Start()
    {
        sceneryAudioSource.loop = true;
    }

    public void Listener(string name)
    {
        effectAudioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }

    public void ScenerySound(string name)
    {
        sceneryAudioSource.clip = Resources.Load<AudioClip>(name);

        sceneryAudioSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        ScenerySound(scene.name);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
