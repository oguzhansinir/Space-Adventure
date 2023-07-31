using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    // !!!!! Sprite Renderer bileþeni yardýmýyla arka plan görselinin tüm mobil cihazlarda tam ekran olacak þekilde görünmesi saðlanýyor.

    // Bu scripti OyunArkaplan objesine ekle.

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();     //Ekrandaki görselin boyutuna müdahale etmek için gerekli.
        Vector2 tempScale = transform.localScale;   //Objenin scale deðerini deðiþkene atadýk.

        float spriteGenislik = spriteRenderer.size.x;
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;    //screen kýsmý hedef cihazý belirtir.
        tempScale.x = ekranGenislik / spriteGenislik;
        transform.localScale = tempScale;

        //Debug.Log("Sprite Geniþlik: " + spriteGenislik);
        //Debug.Log("Ekran Yükseklik: " + ekranYukseklik);
        //Debug.Log("Ekran Geniþlik: " + ekranGenislik);
        //Debug.Log("Temp Scale x: " + tempScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
