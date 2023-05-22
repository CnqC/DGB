using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using UnityEngine.UI;


public class SettingDiaLog : DiaLog, IcomponentChecking
{
    public Slider musicSilder;
    public Slider soundSilder;

    private AudioControler m_auCtr; // l?y ra cái audiocontroler trên scene

    public bool IscomponentNull()
    {
       return  m_auCtr == null || musicSilder == null || soundSilder ==null;
    }

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        m_auCtr = FindAnyObjectByType<AudioControler>();

        if (IscomponentNull()) return;



    }

    public void OnMusicChange(float value) // value = giá trị của thằng slider
    {
        if (IscomponentNull()) return;

        // cập nhập lại volume ở trong cái musicAus của thằng audioCOntroler 

        m_auCtr.musicVol = value;
        m_auCtr.musicAus.volume = value; 
    }

    public void OnSoundChange(float value)
    {
        if (IscomponentNull()) return;

        m_auCtr.soundVol = value;
        m_auCtr.soundAus.volume = value;

    }
}
