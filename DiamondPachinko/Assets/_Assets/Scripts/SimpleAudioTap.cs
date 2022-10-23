using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleAudioTap : MonoBehaviour
{
    private AudioSource hitSound;
    private float pitchMin;
    private float pitchMax;
    
    // Start is called before the first frame update
    void Start()
    {
        pitchMin = 0.8f;
        pitchMax = 1.2f;
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        hitSound.pitch = Random.Range(pitchMin, pitchMax);
        hitSound.Play();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        hitSound.Play();
    }
}

