using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //Bu scripti hiyerar�ide Z�plama butonunun i�ine ekle.

    /*Baz� durumlarda herhangi bir classtan olu�turdu�umuz objenin i�erisinde birtak�m �zellikler olsun isteriz ama bu �zellikler farkl� objelerde de olabilsin. 
     * Yani ayn� classtan gelen iki obje olmas�n, ancak belirli birtak�m �zellikler her ikisinde de olabilsin. Bu gibi yap�larda INTERFACE'ler devreye girer.
    */

    /*  Interface kullanabilmemiz i�in MonoBehaviour'un yan�na IPointerDownHandler,IPointerUpHandler INTERFACE'leri ekledik ancak bunlar� da kullanabilmemiz i�in
     *  public void OnPointerDown(PointerEventData eventData) ve public void OnPointerUp(PointerEventData eventData) metodlar� yazmam�z gerekli.
     *  Yazd���m�z metodlar PointerEventData adl� parametre alacak ancak �nce yukar�da using k�sm�nda EventSystem'i eklememiz gerek.
     *  
     */

    //tusaBasildi'nin public olmas� gerek ��nk� OyuncuHareket scriptinde buna eri�ece�iz.
    //tusaBasildi bool'unu  inspectorda gizlemek i�in [HideInInspector] attribute ekliyoruz. Bu attribute de�i�ken public olsa da inspectorda gizlemek i�in kullan�l�r.
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
