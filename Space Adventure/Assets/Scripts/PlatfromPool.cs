using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromPool : MonoBehaviour
{
    /*  Oyun objeleri tekrar kullan�labilir �ekilde belirli bir say�da �retildikten sonra bir List'in i�erisine dolduruluyor. Burada, ihtiya� duydu�umuz her an oyun objelerini 
     *  yok edip tekrar var etmektense, var olanlar�n yerlerini de�i�tirebilmek ama�lan�yor.
     * 
     * 
     *  Bu scripti hiyerar�ide PlatformPool ad�nda yeni bo� bir obje olu�turup i�ine ekle.
     */



    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject platform2Prefab = default;

    [SerializeField]
    GameObject olumculPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;


    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPozisyon;
    Vector2 playerPozisyon;

    [SerializeField]
    float platformArasiMesafe = default;

    // Start is called before the first frame update
    void Start()
    {
        PlatformUret();
    }

    // Update is called once per frame
    void Update()
    {
        /* Ko�ulun sol taraf� kameran�n g�rd��� en �st taraf� verir. Kameran�n orta noktas�na ekran y�ksekli�ini ekleyince (ko�ulun sa� taraf�) listin i�erisinde son objenin y pozisyonunu ge�mi�se
         * bizim alttaki platformlar� yukar� almam�z laz�m.
         */
        if(platforms[platforms.Count-1].transform.position.y<
            Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }

    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        playerPozisyon = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
        player.transform.parent = ilkPlatform.transform;
        platforms.Add(ilkPlatform);
        SonrakiPlatformPozisyon();
        ilkPlatform.GetComponent<Platform>().Hareket = true;

        for (int i = 0; i < 8; i++)
        {
            float randomPlatform = Random.Range(0.0f, 1.0f);

            if (randomPlatform < 0.5f)
            {
                GameObject uzunPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
                platforms.Add(uzunPlatform);
                uzunPlatform.GetComponent<Platform>().Hareket = true;

                //Oyunun ba��nda gelen platformlarda alt�n ayar�
                if (i % 2 == 0)
                {
                    uzunPlatform.GetComponent<Altin>().AltinAc();
                }
            }
            else
            {
                GameObject kisaPlatform = Instantiate(platform2Prefab, platformPozisyon, Quaternion.identity);
                platforms.Add(kisaPlatform);
                kisaPlatform.GetComponent<Platform>().Hareket = true;

                //Oyunun ba��nda gelen platformlarda alt�n ayar�
                if (i % 2 == 0)
                {
                    kisaPlatform.GetComponent<Altin>().AltinAc();
                }
            }
            SonrakiPlatformPozisyon();
        }
        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozisyon, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiPlatformPozisyon();
    }

    void PlatformYerlestir()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPozisyon;
            
            //Oyun ilerledik�e gelen platformlardaki alt�n ayar�
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                //�nceki bir platformda alt�n varsa ve onu toplamad�ysak o alt�n� �ncelikle kapat�yoruz. ��nk� art�k alt�nlar� platformlara rastgele yerle�tirece�iz.
                platforms[i + 5].GetComponent<Altin>().AltinKapat();
                float rastgeleAltin = Random.Range(0.0f, 1.0f);
                if (rastgeleAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }
            SonrakiPlatformPozisyon();
        }      
    }

    void SonrakiPlatformPozisyon()
    {
        platformPozisyon.y += platformArasiMesafe;
        //SiraliPozisyon();
        KarmaPozisyon();
    }


    void KarmaPozisyon()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }
    }


    bool yon = true;
    void SiraliPozisyon()
    {
        if (yon)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;
            yon = false;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
            yon = true;
        }
    }

}