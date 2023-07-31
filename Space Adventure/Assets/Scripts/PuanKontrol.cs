using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuanKontrol : MonoBehaviour
{
    public Text kolayPuan, kolayAltin, ortaPuan, ortaAltin, zorPuan, zorAltin;


    // Start is called before the first frame update
    void Start()
    {
        kolayPuan.text = "SCORE: " + Secenekler.KolayPuanDegerOku();
        kolayAltin.text = " X " + Secenekler.KolayAltinDegerOku();

        ortaPuan.text = "SCORE: " + Secenekler.OrtaPuanDegerOku();
        ortaAltin.text = " X " + Secenekler.OrtaAltinDegerOku();

        zorPuan.text = "SCORE: " + Secenekler.ZorPuanDegerOku();
        zorAltin.text = " X " + Secenekler.ZorAltinDegerOku();
    }


    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
