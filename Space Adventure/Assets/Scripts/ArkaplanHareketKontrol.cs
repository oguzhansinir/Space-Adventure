using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaplanHareketKontrol : MonoBehaviour
{
    // !!!!! 2 arka plan g�rseli ile kamera d���nda kalan arka plan� her seferinde kamera �er�evesi i�indeki g�rselin �st�ne ta��yarak sonsuza kadar g�rselin devam etmesi sa�lan�yor.

    // Bu scripti OyunArkaplan adl� iki obje se�ili iken inspector paneline s�r�kle b�rak.


    float arkaplanKonum;
    float mesafe = 10.24f;  //�ki arkaplan�n orta noktalar� aras�ndaki mesafe

    // Start is called before the first frame update
    void Start()
    {
        arkaplanKonum = transform.position.y;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaplanKonum);
    }

    // Update is called once per frame
    void Update()
    {
        if (arkaplanKonum + mesafe < Camera.main.transform.position.y)
        {
            ArkaplanYerlestir();
        }
    }

    void ArkaplanYerlestir()
    {
        arkaplanKonum += (mesafe * 2);
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaplanKonum);
        Vector2 yeniPozisyon = new Vector2(0, arkaplanKonum);
        transform.position = yeniPozisyon;
    }
}
