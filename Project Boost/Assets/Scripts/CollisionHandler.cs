using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip onSuccessSFX;
    [SerializeField] AudioClip onFailureSFX;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem failureParticles;

    private AudioSource mAudioSource;
    private bool isPlaying = true;

    private void Start() {
        mAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other) {
        if(isPlaying) {
            switch(other.gameObject.tag) {
                case "Ground":
                case "Obstacle":
                    mAudioSource.Stop();
                    isPlaying = false;
                    HandleCrash();
                    break;
                case "Finish":
                    mAudioSource.Stop();
                    isPlaying = false;
                    HandleSuccess();
                    break;
                default: return;
            }
        }
    }

    private void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HandleSuccess() {
        mAudioSource.PlayOneShot(onSuccessSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    private void HandleCrash() {
        mAudioSource.PlayOneShot(onFailureSFX);
        failureParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ResetScene", delay);
    }

    private void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = 0;
        if(currentSceneIndex != SceneManager.sceneCount) {
            nextScene = currentSceneIndex + 1;
        }
        SceneManager.LoadScene(nextScene);
    }
}
