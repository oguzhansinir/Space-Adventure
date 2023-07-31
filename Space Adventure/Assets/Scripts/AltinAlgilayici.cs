using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    //Bu scripti Alt�n objesinin i�ine ekle.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ayaklar")
        {
            //Altin scripti bu scriptin ekli oldu�u objenin parentinda oldu�u i�in Altin scriptine ula�mak i�in a�a��daki yolu izliyoruz. 
            GetComponentInParent<Altin>().AltinKapat();
            FindObjectOfType<Puan>().AltinKazan();
        }
    }
}
