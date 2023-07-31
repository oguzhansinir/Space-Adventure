using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AyarlarKontrol : MonoBehaviour
{
    //Bu scripti hiyerarþide AyarlarKontrol adlý boþ bir obje oluþturarak içine ekle.

    public Button kolayButon, ortaButon, zorButon;

    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KolayDegerOku() == 1)
        {
            kolayButon.interactable = false;
            ortaButon.interactable = true;
            zorButon.interactable = true;
        }
        if (Secenekler.OrtaDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = false;
            zorButon.interactable = true;
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            kolayButon.interactable = true;
            ortaButon.interactable = true;
            zorButon.interactable = false;
        }
    }


    public void SecenekSecildi(string seviye)
    {
        switch (seviye)
        {
            case "kolay":
                Secenekler.KolayDegerAta(1);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(0);
                kolayButon.interactable = false;
                ortaButon.interactable = true;
                zorButon.interactable = true;
                break;

            case "orta":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(1);
                Secenekler.ZorDegerAta(0);
                kolayButon.interactable = true;
                ortaButon.interactable = false;
                zorButon.interactable = true;
                break;

            case "zor":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(1);
                kolayButon.interactable = true;
                ortaButon.interactable = true;
                zorButon.interactable = false;
                break;

            default:
                break;
        }
    }

     public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
