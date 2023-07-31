using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    /* Karakterimizin yürüme, zýplama gibi hareketleri yapabilmesi için Rigidbody 2D bileþeni lazým. 
     * Sahnede Player seçili iken Inspector panelinden Add Component'a týklayarak Rigidbody 2D'yi ekle.
     * Fizik kurallarýný artýk geçerli hale getirdik.
     * Player'a Box Collider 2D ekle.
     *
     * Bu scripti Player objesine ekle.
     */




    Rigidbody2D rb2D;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float hiz = default;    //3

    [SerializeField]
    float hizlanma = default;   //10

    [SerializeField]
    float yavaslama = default;  //20

    [SerializeField]
    float ziplamaGucu;

    [SerializeField]
    int ziplamaLimit = 3;

    int ziplamaSayisi;

    JoystickButon joystickButon;

    bool zipliyor;


    float dirx;

    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        joystickButon = FindObjectOfType<JoystickButon>();
    }

    void Update()
    {
        OyuncuEkranHareket();
    }

    

    

    void OyuncuEkranHareket()
    {

        dirx = Input.acceleration.x * hizlanma;
        
        Vector2 scale = transform.localScale;
        

        if (dirx > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, dirx * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.5f;
        }
        else if(dirx < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, dirx * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.5f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }


        transform.localScale = scale;
        
        transform.Translate(velocity * Time.deltaTime);

        if (joystickButon.tusaBasildi == true && zipliyor == false)
        {
            zipliyor = true;
            ZiplamayiBaslat();
        }
        if (joystickButon.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }


    /* Zýplamanýn daha makul olabilmesi için Player prefabý seçili iken Rigidboy2D'ye girip Mass=5(kütle) Linear Drag=4(doðrusal sürtünme) Gravity Scale=5(yerçekimi skalasý) deðerlerini giriyoruz.
     *  Zýplama Gücü deðerini de 100 olarak giriyoruz.
     */

    void ZiplamayiBaslat()
    {
        if (ziplamaSayisi < ziplamaLimit)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            rb2D.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimit, ziplamaSayisi);
            
        }
    }

    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimit, ziplamaSayisi);
        
    }

    //Platform scriptinde bu metoda eriþebilmek için public yaptýk.
    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        Debug.Log("Zýplama sýfýrlandý");
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimit, ziplamaSayisi);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }


    public void OyunBitti()
    {
        Destroy(gameObject);
    }



}
