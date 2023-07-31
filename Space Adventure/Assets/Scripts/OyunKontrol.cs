using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    //Bu scripti hiyerarþideki OyunKontrol adlý objenin içine ekle.
    //Bu scripte sahneler arasý geçiþi kullanacaðýmýz için yukarýda SceneManagement kütüphanesini ekle.


    public GameObject oyunBittiPanel;
    public GameObject durdurPanel;
    //public GameObject joystick;
    public GameObject ziplamaButonu;
    public GameObject tabela;
    public GameObject menuButonu;
    public GameObject slider;


    // Start is called before the first frame update
    void Start()
    {
        oyunBittiPanel.SetActive(false);
        UIAc();
        Time.timeScale = 1;
    }


    public void OyunuBitir()
    {
        FindObjectOfType<SesKontrol>().OyunBittiSes();
        oyunBittiPanel.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        UIKapat();
    }


    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
        UIAc();
        Time.timeScale = 1;
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
        UIAc();
        Time.timeScale = 1;
    }

    public void Durdur()
    {
        durdurPanel.SetActive(true);
        UIKapat();
        Time.timeScale = 0;
    }

    public void DevamEt()
    {
        durdurPanel.SetActive(false);
        UIAc();
        Time.timeScale = 1;
    }

    void UIAc()
    {
        //joystick.SetActive(true);
        ziplamaButonu.SetActive(true);
        tabela.SetActive(true);
        menuButonu.SetActive(true);
        slider.SetActive(true);
    }

    void UIKapat()
    {
        //joystick.SetActive(false);
        ziplamaButonu.SetActive(false);
        tabela.SetActive(false);
        menuButonu.SetActive(false);
        slider.SetActive(false);
    }

}
