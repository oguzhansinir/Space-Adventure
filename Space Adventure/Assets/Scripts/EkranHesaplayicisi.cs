using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayicisi : MonoBehaviour
{
    //Singleton Pattern kullanýlarak proje dahilindeki tüm sahnelerde kullanýlabilir ve dönüþ deðeri olarak ekran boyutunu gönderen metotlarý içeren Class oluþturuluyor.

    //Bu scripti Hiyerarþide EkranHesaplayicisi adýnda yeni boþ bir obje oluþturup içine ekle.

    public static EkranHesaplayicisi instance; //Singleton olarak kullanmamýz için gerekli kod.

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

    //Tüm hesaplamalardan önce kullanýlmasý için Start yerine Awake kullanýyoruz.
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
