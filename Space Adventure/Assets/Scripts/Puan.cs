using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    //Bu scripti hiyerarþide PuanKontrol adlý boþ bir obje oluþturup içine ekle.

    int puan;
    int enYuksekPuan;

    int altin;
    int enYuksekAltin;

    bool puanTopla = true;

    [SerializeField]
    Text puanText = default;

    [SerializeField]
    Text altinText = default;

    [SerializeField]
    Text oyunBittiPuanText = default;

    [SerializeField]
    Text oyunBittiAltinText = default;

    // Start is called before the first frame update
    void Start()
    {
        altinText.text = " X " + altin;
    }

    // Update is called once per frame
    void Update()
    {
        if (puanTopla)
        {
            puan = (int)Camera.main.transform.position.y;
            puanText.text = "Score: " + puan;
        }

    }


    public void AltinKazan()
    {
        FindObjectOfType<SesKontrol>().AltinSes();
        altin++;
        altinText.text = " X " + altin;
    }

    public void OyunBitti()
    {
        if (Secenekler.KolayDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.KolayPuanDegerOku();
            enYuksekAltin = Secenekler.KolayAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.KolayPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.KolayAltinDegerAta(altin);
            }
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.OrtaPuanDegerOku();
            enYuksekAltin = Secenekler.OrtaAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.OrtaPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.OrtaAltinDegerAta(altin);
            }
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.ZorPuanDegerOku();
            enYuksekAltin = Secenekler.ZorAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.ZorPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.ZorAltinDegerAta(altin);
            }
        }

        puanTopla = false;
        oyunBittiPuanText.text = "Score: " + puan;
        oyunBittiAltinText.text = " X " + altin;
    }

}
