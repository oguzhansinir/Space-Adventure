using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    //Bu scripti Altýn objesinin ekli olduðu Platform prefabine ekle. Platforma ekledik çünkü altýný açýp kapatmak için.


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
