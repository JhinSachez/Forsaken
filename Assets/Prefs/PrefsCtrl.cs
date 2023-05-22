using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrefsCtrl : MonoBehaviour
{
    private int volumen;
    [SerializeField] private TMP_Text txt_volumen;

    void Start()
    {
        if (!PlayerPrefs.HasKey("volumen"))
        {
            PlayerPrefs.SetInt("volumen", 5);
        }

        volumen = PlayerPrefs.GetInt("volumen");
        txt_volumen.text = volumen.ToString();
    }

    public void Btn_mas()
    {
        if (volumen < 10)
        {
            volumen++;
            txt_volumen.text = volumen.ToString();
        }
    }

    public void Btn_menos()
    {
        if (volumen > 0)
        {
            volumen--;
            txt_volumen.text = volumen.ToString();
        }
    }

    public void Btn_guardar()
    {
        PlayerPrefs.SetInt("volumen", volumen);
    }
}
