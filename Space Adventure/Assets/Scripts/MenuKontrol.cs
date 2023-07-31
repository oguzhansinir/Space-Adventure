using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    //Bu scripti Hiyerarþide yeni bir oyun objesi oluþtur ve içine ekle.

    //Sahneler arasý geçiþ yapabilmek için yukarýda SceneManagement kütüphanesini ekliyoruz.

    /*File-->Build Settings'e geliyoruz.
	  Sahneleri sürükleyip Build Settings penceresinde sahneler kýsmýna ekliyoruz.
    */

    /* Ýlgili butona týkladýktan sonra metodun çaðrýlmasý için:
     * Sahneden ilgili butonu seçip On Click'e gelip + tuþuna basarak MenuKontrol objesini sürükleyip býrakýyoruz.
     * Function kýsmýndan ise ilgili metodu çaðýrýyoruz.
     */

    [SerializeField]
    Sprite[] muzikIkonlar = default;    //Müziðin açýk veya kapalý olmasý durumlarý için.

    [SerializeField]
    Button muzikButon = default;    //Bu scriptin buton özelliðini kullanabilmesi için yukarýda UI kütüphanesini ekliyoruz.

    

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
