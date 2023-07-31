using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    // !!!!! Sprite Renderer bile�eni yard�m�yla arka plan g�rselinin t�m mobil cihazlarda tam ekran olacak �ekilde g�r�nmesi sa�lan�yor.

    // Bu scripti OyunArkaplan objesine ekle.

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();     //Ekrandaki g�rselin boyutuna m�dahale etmek i�in gerekli.
        Vector2 tempScale = transform.localScale;   //Objenin scale de�erini de�i�kene atad�k.

        float spriteGenislik = spriteRenderer.size.x;
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;    //screen k�sm� hedef cihaz� belirtir.
        tempScale.x = ekranGenislik / spriteGenislik;
        transform.localScale = tempScale;

        //Debug.Log("Sprite Geni�lik: " + spriteGenislik);
        //Debug.Log("Ekran Y�kseklik: " + ekranYukseklik);
        //Debug.Log("Ekran Geni�lik: " + ekranGenislik);
        //Debug.Log("Temp Scale x: " + tempScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
