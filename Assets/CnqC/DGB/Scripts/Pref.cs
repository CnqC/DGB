using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

public static class Pref 
{
    public static int bestScore 
    {
        set// lưu điểm số cao nhất
        {
            int oldBestScore = PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0); //0 là giá trị mặc định khi k lấy được hay chưa chơi
                                                                             // lấy ra giá trị kiểu Int trong Script Const phần BestScorePRef
            if (oldBestScore < value) // khi mà giá trị của oldBestCore nhỏ hơn giá trị cũ mà ta đã lưu cua biến oldBestCore thì ta sẽ lưu cái mới nhất mà cao nhất
                PlayerPrefs.SetInt(Const.BEST_SCORE_PREF, value); // lưu đè dữ liệu mới lên cũ xuống máy ng dùng 

        }

        get => PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0); // lấy ra điểm số cao nhất của ng dùng

    }
    public static int curPlayeriD
    {
        set => PlayerPrefs.SetInt(Const.CUR_PLAYER_ID_PREF, value);

        get => PlayerPrefs.GetInt(Const.CUR_PLAYER_ID_PREF, 0);
    }

    public static int coins
    {
        set => PlayerPrefs.SetInt(Const.COINS_PREF, value);
        get => PlayerPrefs.GetInt(Const.COINS_PREF, 0);
    }

    public static float musicVol
    {
        set => PlayerPrefs.SetFloat(Const.MUSIC_VOL_PREF, value);
        get => PlayerPrefs.GetFloat(Const.SOUND_VOL_PREF, 0);
    }

    public static float soundVol
    {
        set => PlayerPrefs.SetFloat(Const.SOUND_VOL_PREF, value);
        get => PlayerPrefs.GetFloat(Const.SOUND_VOL_PREF, 0);
    }



    // kiểm tra xem ta lưu hay lấy giá trị dưới máy người dùng thế nào, nếu như t lưu hay lấy được nó sẽ trả ra là Key =1 , value = true và ngược lại
    public static void SetBool(string key , bool value ) 
    {
        if (value) // ktr value = true
            PlayerPrefs.SetInt(key, 1);
        else
            PlayerPrefs.SetInt(key, 0);
    }

    public static bool GetBool(string key)
    {
        int check = PlayerPrefs.GetInt(key) ;
        if (check == 0)
            return false;
        else if (check == 1)
            return true;

        return false; // các trường hợp khác trả về false
    }
}

