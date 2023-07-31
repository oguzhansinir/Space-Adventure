using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    //Bu scripti SesKontrol'e ekle.

    public AudioClip ziplama;
    public AudioClip altin;
    public AudioClip oyunBitti;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ZiplamaSes()
    {
        audioSource.clip = ziplama;
        audioSource.Play();
    }


    public void AltinSes()
    {
        audioSource.clip = altin;
        audioSource.Play();
    }


    public void OyunBittiSes()
    {
        audioSource.clip = oyunBitti;
        audioSource.Play();
    }

}
