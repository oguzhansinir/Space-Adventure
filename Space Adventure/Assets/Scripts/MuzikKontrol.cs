using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    //Bu scripti Menu sahnesindeki MuzikKontrol adl� objeye ekle.
    //Bu scripti singleton olarak kullan. Yani bundan proje boyunca bir tane olsun ve sahne ne olursa olsun arkaplan m�zi�i de�i�mesin.

    public static MuzikKontrol instance;

    AudioSource audioSource;


    void Start()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }


    void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);    //Sahneler aras� ge�i�te bu instance'� yok etme demi� olduk ki her sahnede arkaplan m�zi�i �almaya devam etsin.
        }
    }


    public void MuzikCal(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }


}
