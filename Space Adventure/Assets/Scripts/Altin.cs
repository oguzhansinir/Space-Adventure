using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    //Bu scripti Alt�n objesinin ekli oldu�u Platform prefabine ekle. Platforma ekledik ��nk� alt�n� a��p kapatmak i�in.


    [SerializeField]
    GameObject altin = default;

    public void AltinAc()
    {
        altin.SetActive(true);
    }

    public void AltinKapat()
    {
        altin.SetActive(false);
    }

}
