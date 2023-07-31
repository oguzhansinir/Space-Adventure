using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    //Bu scripti Hiyerar�ide yeni bir oyun objesi olu�tur ve i�ine ekle.

    //Sahneler aras� ge�i� yapabilmek i�in yukar�da SceneManagement k�t�phanesini ekliyoruz.

    /*File-->Build Settings'e geliyoruz.
	  Sahneleri s�r�kleyip Build Settings penceresinde sahneler k�sm�na ekliyoruz.
    */

    /* �lgili butona t�klad�ktan sonra metodun �a�r�lmas� i�in:
     * Sahneden ilgili butonu se�ip On Click'e gelip + tu�una basarak MenuKontrol objesini s�r�kleyip b�rak�yoruz.
     * Function k�sm�ndan ise ilgili metodu �a��r�yoruz.
     */

    [SerializeField]
    Sprite[] muzikIkonlar = default;    //M�zi�in a��k veya kapal� olmas� durumlar� i�in.

    [SerializeField]
    Button muzikButon = default;    //Bu scriptin buton �zelli�ini kullanabilmesi i�in yukar�da UI k�t�phanesini ekliyoruz.

    

    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KayitVarMi() == false)
        {
            Secenekler.KolayDegerAta(1);
        }

        if (Secenekler.MuzikAcikKayitVarMi() == false)
        {
            Secenekler.MuzikAcikDegerAta(1);
        }

        MuzikAyarlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if (Secenekler.MuzikAcikDegerOku()==1)
        {
            Secenekler.MuzikAcikDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            Secenekler.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }


    void MuzikAyarlariniDenetle()
    {
        if (Secenekler.MuzikAcikDegerOku() == 1)
        {
            muzikButon.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        }
        else
        {
            muzikButon.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }
}
