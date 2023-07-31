using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    //Bu scripti Altýn objesinin içine ekle.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ayaklar")
        {
            //Altin scripti bu scriptin ekli olduðu objenin parentinda olduðu için Altin scriptine ulaþmak için aþaðýdaki yolu izliyoruz. 
            GetComponentInParent<Altin>().AltinKapat();
            FindObjectOfType<Puan>().AltinKazan();
        }
    }
}
