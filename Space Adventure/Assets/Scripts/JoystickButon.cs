using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //Bu scripti hiyerarþide Zýplama butonunun içine ekle.

    /*Bazý durumlarda herhangi bir classtan oluþturduðumuz objenin içerisinde birtakým özellikler olsun isteriz ama bu özellikler farklý objelerde de olabilsin. 
     * Yani ayný classtan gelen iki obje olmasýn, ancak belirli birtakým özellikler her ikisinde de olabilsin. Bu gibi yapýlarda INTERFACE'ler devreye girer.
    */

    /*  Interface kullanabilmemiz için MonoBehaviour'un yanýna IPointerDownHandler,IPointerUpHandler INTERFACE'leri ekledik ancak bunlarý da kullanabilmemiz için
     *  public void OnPointerDown(PointerEventData eventData) ve public void OnPointerUp(PointerEventData eventData) metodlarý yazmamýz gerekli.
     *  Yazdýðýmýz metodlar PointerEventData adlý parametre alacak ancak önce yukarýda using kýsmýnda EventSystem'i eklememiz gerek.
     *  
     */

    //tusaBasildi'nin public olmasý gerek çünkü OyuncuHareket scriptinde buna eriþeceðiz.
    //tusaBasildi bool'unu  inspectorda gizlemek için [HideInInspector] attribute ekliyoruz. Bu attribute deðiþken public olsa da inspectorda gizlemek için kullanýlýr.
    [HideInInspector]
    public bool tusaBasildi;


    public void OnPointerDown(PointerEventData eventData)
    {
        tusaBasildi = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        tusaBasildi = false;
    }


}
