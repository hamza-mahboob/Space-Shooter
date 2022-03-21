using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVFX : MonoBehaviour
{
    public ParticleSystem ps;
    AudioSource audioSource;
    public AudioClip clip;
    private void Update()
    {
        ps.transform.position = transform.position;
    }
    private void OnDestroy()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        ps.Play();
    }
}
