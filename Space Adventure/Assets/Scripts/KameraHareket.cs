using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    // !!!!! Hýz, Hýzlanma ve Maksimum Hýz parametreleri ile Kameranýn Y ekseninde sürekli olarak ve Maksimum Hýz limitine kadar hýzlanarak yukarý çýkmasý saðlanýyor.

    /*Hiyerarþide Arkaplan adlý yeni boþ bir obje oluþtur. OyunArkaplan'ý da Arkaplan'a sürükleyip býrakarak çocuðu yap. OyunArkaplan seçili iken Ctrl+D yaparak aynýsýndan bir adet daha üretiyoruz.
     * Ýkimci objeyi Y ekseninde yukarý doðru hareket ettir. Bu iki objenin uçlarýnýn birbirine tam olarak temas etmesi için klavyeden V tuþuna basýlý tutarak köþesinden tutup diðer objenin köþesine çek.
    */

    // Bu scripti Main Camera'ya ekle.



    float hiz;  //Kameranýn anlýk hýzý.
    float hizlanma; //Zaman içersinde ne kadarlýk bir hýzlanma
    float maksimumHiz;  //Kameranýn maksimum hýzý.

    bool hareket = true;    //Kamera hareketini durdurup baþlatmak için

    /*EÐER OYUN SONUNDA KAMERA HAREKETÝNÝN DURMASINI ÝSTERSEK YUKARIDAKÝ BOOL HAREKETÝ START ÝÇERÝSÝNDE TRUE OLARAK ATAMALIYIZ,
     * DAHA SONRA BU KOD ALANININ EN ALTINDA AÞAÐIDAKÝ OYUN BÝTTÝ METODUNU OLUÞTURUP BU METODU OYUN KONTROL SCRÝPTÝNDE OYUNU BÝTÝR METODUNUN ÝÇERÝSÝNDE ÇAÐIRMALIYIZ.
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
        transform.position += transform.up * hiz * Time.deltaTime; //transformdaki up bölümü Y deðerini otomatik olarak arttýran bölüm.
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maksimumHiz)
        {
            hiz = maksimumHiz;
        }
    }
}
