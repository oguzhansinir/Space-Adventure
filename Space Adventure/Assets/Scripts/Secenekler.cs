using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Secenekler
{
    //
    /* Yukarýdaki MonoBehaviour'u sil. Çünkü bu script herhangi bir oyun objesine ekli bir component olarak çalýþmayacak. Bizim buna tüm sahnelerden dilediðimiz anda eriþebilmemiz lazým bu yüzden
     * bu classý static yapýyoruz. Böylece içindeki hiçbir deðer deðiþmeden istediðimiz her yerden eriþebiliriz.
     */

    public static string kolay = "kolay";
    public static string orta = "orta";
    public static string zor = "zor";

    public static string kolayPuan = "kolayPuan";
    public static string ortaPuan = "ortaPuan";
    public static string zorPuan = "zorPuan";

    public static string kolayAltin = "kolayAltin";
    public static string ortaAltin = "ortaAltin";
    public static string zorAltin = "zorAltin";

    public static string muzikAcik = "muzikAcik";

    public static void KolayDegerAta(int kolay)
    {
        PlayerPrefs.SetInt(Secenekler.kolay, kolay);
    }

    public static int KolayDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.kolay);
    }



    public static void OrtaDegerAta(int orta)
    {
        PlayerPrefs.SetInt(Secenekler.orta, orta);
    }

    public static int OrtaDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.orta);
    }



    public static void ZorDegerAta(int zor)
    {
        PlayerPrefs.SetInt(Secenekler.zor, zor);
    }

    public static int ZorDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.zor);
    }






    public static void KolayPuanDegerAta(int kolayPuan)
    {
        PlayerPrefs.SetInt(Secenekler.kolayPuan, kolayPuan);
    }

    public static int KolayPuanDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.kolayPuan);
    }



    public static void OrtaPuanDegerAta(int ortaPuan)
    {
        PlayerPrefs.SetInt(Secenekler.ortaPuan, ortaPuan);
    }

    public static int OrtaPuanDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.ortaPuan);
    }



    public static void ZorPuanDegerAta(int zorPuan)
    {
        PlayerPrefs.SetInt(Secenekler.zorPuan, zorPuan);
    }

    public static int ZorPuanDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.zorPuan);
    }




    public static void KolayAltinDegerAta(int kolayAltin)
    {
        PlayerPrefs.SetInt(Secenekler.kolayAltin, kolayAltin);
    }

    public static int KolayAltinDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.kolayAltin);
    }



    public static void OrtaAltinDegerAta(int ortaAltin)
    {
        PlayerPrefs.SetInt(Secenekler.ortaAltin, ortaAltin);
    }

    public static int OrtaAltinDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.ortaAltin);
    }



    public static void ZorAltinDegerAta(int zorAltin)
    {
        PlayerPrefs.SetInt(Secenekler.zorAltin, zorAltin);
    }

    public static int ZorAltinDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.zorAltin);
    }




    public static void MuzikAcikDegerAta(int muzikAcik)
    {
        PlayerPrefs.SetInt(Secenekler.muzikAcik, muzikAcik);
    }

    public static int MuzikAcikDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.muzikAcik);
    }


    public static bool KayitVarMi()
    {
        if (PlayerPrefs.HasKey(Secenekler.kolay) || PlayerPrefs.HasKey(Secenekler.orta) || PlayerPrefs.HasKey(Secenekler.zor))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool MuzikAcikKayitVarMi()
    {
        if (PlayerPrefs.HasKey(Secenekler.muzikAcik))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
