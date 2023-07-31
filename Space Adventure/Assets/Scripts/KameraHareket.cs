using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    // !!!!! H�z, H�zlanma ve Maksimum H�z parametreleri ile Kameran�n Y ekseninde s�rekli olarak ve Maksimum H�z limitine kadar h�zlanarak yukar� ��kmas� sa�lan�yor.

    /*Hiyerar�ide Arkaplan adl� yeni bo� bir obje olu�tur. OyunArkaplan'� da Arkaplan'a s�r�kleyip b�rakarak �ocu�u yap. OyunArkaplan se�ili iken Ctrl+D yaparak ayn�s�ndan bir adet daha �retiyoruz.
     * �kimci objeyi Y ekseninde yukar� do�ru hareket ettir. Bu iki objenin u�lar�n�n birbirine tam olarak temas etmesi i�in klavyeden V tu�una bas�l� tutarak k��esinden tutup di�er objenin k��esine �ek.
    */

    // Bu scripti Main Camera'ya ekle.



    float hiz;  //Kameran�n anl�k h�z�.
    float hizlanma; //Zaman i�ersinde ne kadarl�k bir h�zlanma
    float maksimumHiz;  //Kameran�n maksimum h�z�.

    bool hareket = true;    //Kamera hareketini durdurup ba�latmak i�in

    /*E�ER OYUN SONUNDA KAMERA HAREKET�N�N DURMASINI �STERSEK YUKARIDAK� BOOL HAREKET� START ��ER�S�NDE TRUE OLARAK ATAMALIYIZ,
     * DAHA SONRA BU KOD ALANININ EN ALTINDA A�A�IDAK� OYUN B�TT� METODUNU OLU�TURUP BU METODU OYUN KONTROL SCR�PT�NDE OYUNU B�T�R METODUNUN ��ER�S�NDE �A�IRMALIYIZ.
     * 
     * public void OyunBitti()
     * {
     *      hareket=false;
     * }
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KolayDegerOku() == 1)
        {
            hiz = 0.3f;
            hizlanma = 0.03f;
            maksimumHiz = 1.5f;
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            hiz = 0.5f;
            hizlanma = 0.05f;
            maksimumHiz = 2.0f;
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            hiz = 0.8f;
            hizlanma = 0.08f;
            maksimumHiz = 2.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            KamerayiHareketEttir();
        }
        
    }

    void KamerayiHareketEttir()
    {
        transform.position += transform.up * hiz * Time.deltaTime; //transformdaki up b�l�m� Y de�erini otomatik olarak artt�ran b�l�m.
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maksimumHiz)
        {
            hiz = maksimumHiz;
        }
    }
}
