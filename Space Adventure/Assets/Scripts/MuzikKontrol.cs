using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    //Bu scripti Menu sahnesindeki MuzikKontrol adlý objeye ekle.
    //Bu scripti singleton olarak kullan. Yani bundan proje boyunca bir tane olsun ve sahne ne olursa olsun arkaplan müziði deðiþmesin.

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
            DontDestroyOnLoad(instance);    //Sahneler arasý geçiþte bu instance'ý yok etme demiþ olduk ki her sahnede arkaplan müziði çalmaya devam etsin.
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
