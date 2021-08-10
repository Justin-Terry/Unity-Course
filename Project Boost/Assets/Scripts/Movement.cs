using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float upwardThrustLevel = 1f;
    [SerializeField] float rotationThrustLevel = 1f;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] ParticleSystem thrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;


    private Rigidbody mRigidbody;
    private AudioSource mAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else {
            thrustParticles.Stop();
            mAudioSource.Stop();
        }
    }

    private void ProcessRotation() {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            ThrustLeft();
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            ThrustRight();
        }
        else {
            leftThrustParticles.Stop();
            rightThrustParticles.Stop();
        }
    }

    private void StartThrust()
    {
        if (!thrustParticles.isPlaying)
        {
            thrustParticles.Play();
        }
        if (!mAudioSource.isPlaying)
        {
            mAudioSource.PlayOneShot(thrustSound);
        }
        mRigidbody.AddRelativeForce(Vector3.up * upwardThrustLevel * Time.deltaTime);
    }

    private void ThrustRight()
    {
        if (!rightThrustParticles.isPlaying)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }

        ApplyRotation(-rotationThrustLevel);
    }

    private void ThrustLeft()
    {
        if (!leftThrustParticles.isPlaying)
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Play();
        }

        ApplyRotation(rotationThrustLevel);
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        mRigidbody.AddRelativeTorque(new Vector3(0f, 0.25f * Time.deltaTime, 1 * rotationThisFrame * Time.deltaTime));
    }
}
