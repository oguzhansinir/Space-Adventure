using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderKontrol : MonoBehaviour
{
    //Bu scripti hiyerarþideki Slider objesinin içine ekle.

    //Slider da bir UI elementi olduðu için yukarýda UI kütüphanesini ekle.

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }


    public void SliderDeger(int maxDeger,int gecerliDeger)
    {
        int sliderDeger = maxDeger - gecerliDeger;
        slider.maxValue = maxDeger;
        slider.value = sliderDeger;
    }

}
