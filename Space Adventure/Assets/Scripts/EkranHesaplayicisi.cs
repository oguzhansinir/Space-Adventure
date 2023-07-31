using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayicisi : MonoBehaviour
{
    //Singleton Pattern kullan�larak proje dahilindeki t�m sahnelerde kullan�labilir ve d�n�� de�eri olarak ekran boyutunu g�nderen metotlar� i�eren Class olu�turuluyor.

    //Bu scripti Hiyerar�ide EkranHesaplayicisi ad�nda yeni bo� bir obje olu�turup i�ine ekle.

    public static EkranHesaplayicisi instance; //Singleton olarak kullanmam�z i�in gerekli kod.

    float yukseklik;
    float genislik;

    public float Yukseklik
    {
        get
        {
            return yukseklik;
        }
    }

    public float Genislik
    {
        get
        {
            return genislik;
        }
    }

    //T�m hesaplamalardan �nce kullan�lmas� i�in Start yerine Awake kullan�yoruz.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        yukseklik = Camera.main.orthographicSize;
        genislik = yukseklik * Camera.main.aspect;
    }

    //void Update()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }

    //    yukseklik = Camera.main.orthographicSize;
    //    genislik = yukseklik * Camera.main.aspect;
    //}
}
