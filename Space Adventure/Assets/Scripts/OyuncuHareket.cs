using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    /* Karakterimizin y�r�me, z�plama gibi hareketleri yapabilmesi i�in Rigidbody 2D bile�eni laz�m. 
     * Sahnede Player se�ili iken Inspector panelinden Add Component'a t�klayarak Rigidbody 2D'yi ekle.
     * Fizik kurallar�n� art�k ge�erli hale getirdik.
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


    /* Z�plaman�n daha makul olabilmesi i�in Player prefab� se�ili iken Rigidboy2D'ye girip Mass=5(k�tle) Linear Drag=4(do�rusal s�rt�nme) Gravity Scale=5(yer�ekimi skalas�) de�erlerini giriyoruz.
     *  Z�plama G�c� de�erini de 100 olarak giriyoruz.
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

    //Platform scriptinde bu metoda eri�ebilmek i�in public yapt�k.
    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        Debug.Log("Z�plama s�f�rland�");
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
