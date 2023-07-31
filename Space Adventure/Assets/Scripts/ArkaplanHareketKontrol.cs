using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaplanHareketKontrol : MonoBehaviour
{
    // !!!!! 2 arka plan görseli ile kamera dýþýnda kalan arka planý her seferinde kamera çerçevesi içindeki görselin üstüne taþýyarak sonsuza kadar görselin devam etmesi saðlanýyor.

    // Bu scripti OyunArkaplan adlý iki obje seçili iken inspector paneline sürükle býrak.


    float arkaplanKonum;
    float mesafe = 10.24f;  //Ýki arkaplanýn orta noktalarý arasýndaki mesafe

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
